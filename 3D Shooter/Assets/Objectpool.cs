using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Objectpool : MonoBehaviour
{
    public GameObject prefab;
    public int spawnAmount;
    public List<GameObject> objectpool = new List<GameObject>();
    public Transform[] spawnPoints;

    void Awake()
    {
        CreatePool();
    }

    private void Start()
    {
        InvokeRepeating("SpawnFromPool", 3f, Random.Range(2,6));
    }

    void CreatePool()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.SetActive(false);
            objectpool.Add(go);
        }
    }

    void SpawnFromPool()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            if (!objectpool[i].activeSelf)
            {
                //objectpool[i].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                objectpool[i].GetComponent<NavMeshAgent>().Warp(spawnPoints[Random.Range(0, spawnPoints.Length)].position);
                objectpool[i].transform.rotation = Quaternion.identity;


                objectpool[i].SetActive(true);

                break;
            }           
        }
    }
}
