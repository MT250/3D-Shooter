using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    [SerializeField]
    private float delay = 0.3f;

	void Start () {
        Destroy(gameObject, delay);
    }
}
