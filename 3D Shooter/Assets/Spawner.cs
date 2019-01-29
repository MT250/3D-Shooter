using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    [SerializeField]
    private float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, spawnDelay);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
    }
}
