using UnityEngine;

public class ExplosionDamage : MonoBehaviour {

    public float explosionFullDamage = 200f;

	// Use this for initialization
	void Start () {

        float radius = 10 * 1.5f;
        var collisions = Physics.OverlapSphere(transform.position, radius);

        foreach (var col in collisions)
        {
            Target target = col.GetComponent<Target>();

            if (target != null)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    target.TakeDamage(explosionFullDamage / distance);
                }
        }
	}
}
