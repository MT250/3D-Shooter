using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float health = 50f;
    [SerializeField]
    private float killReward;
    [Space]
    [Header("Explosive")]
    [SerializeField]
    private bool explodeOnDeath = false;
    [SerializeField]
    private GameObject explosionPrefab;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 )
            {
                game_manager.instance.AddScore(killReward);
                Destroy(gameObject);
                if (explodeOnDeath) { Instantiate(explosionPrefab, transform.position, transform.rotation); explodeOnDeath = false; }
            }
    }

}
