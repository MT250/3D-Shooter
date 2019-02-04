using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform target;
    NavMeshAgent navAgent;

    public float biteCooldown = 2f;
    [SerializeField]
    private float curBiteCooldown;

    void Start()
    {
        target = PlayerManager.instace.player.transform;
        navAgent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        //Set destination to players position
        navAgent.SetDestination(target.position);
        float dis = Vector3.Distance(target.position, transform.position);
        //Bite cooldown
        if (curBiteCooldown > 0) curBiteCooldown -= Time.deltaTime;

        if (dis <= navAgent.stoppingDistance)
        {
            //Face player
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * .1f);
            //Attack player
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward, out hit, 3f))
            {
                Debug.Log("Bite: " + hit.transform.name);
                if(hit.transform.tag == "Player" && curBiteCooldown <= 0)
                {
                    PlayerManager.instace.TakeDamage(Random.Range(2f, 7f));
                    curBiteCooldown = biteCooldown;
                }
            }
            
        }
    }
}
