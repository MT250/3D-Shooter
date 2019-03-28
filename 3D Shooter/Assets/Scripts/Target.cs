using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float maxHealth = 50f;
    [SerializeField]
    private float killReward;

    [Space]
    [Header("Drops medkit")]
    [SerializeField]
    private bool drop = false;
    [SerializeField]
    private GameObject medkitPrefab;
    [SerializeField]
    [Range(0f,100f)]
    private float dropChance;
    [Space]
    [Header("Explosive")]

    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private bool explodeOnDeath = false;
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0 )
            {
                game_manager.instance.AddScore(killReward);
                gameObject.SetActive(false);
                //Will Explode ?
                if (explodeOnDeath)
                    {
                        Instantiate(explosionPrefab, transform.position, transform.rotation);
                        explodeOnDeath = false;
                    }
                //Will drop Medkit
                if (drop)
                    {
                        if (Random.Range(0, 100) <= dropChance) { Instantiate(medkitPrefab, transform.position, transform.rotation); } 
                    }

            }
    }
}
