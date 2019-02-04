using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float healAmount = 10f;
    public float rotateSpeed = 2f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Rotate(0,rotateSpeed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instace.Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
