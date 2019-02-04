﻿using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private float health = 50f;
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
                //Explosion
                if (explodeOnDeath) { Instantiate(explosionPrefab, transform.position, transform.rotation); explodeOnDeath = false; }
                //Medkit drop
                if (drop)
                    {
                        if (Random.Range(0, 100) <= dropChance) { Instantiate(medkitPrefab, transform.position, transform.rotation); } 
                    }

            }
    }

}
