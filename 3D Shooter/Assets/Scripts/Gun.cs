using UnityEngine;

public class Gun : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float impactForce = 40f;

    [Header("Components")]
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private Light pointLight;
    [SerializeField]
    private GameObject impact;
    [SerializeField]
    private AudioSource shootSound;

	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        shootSound.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();

            if (target != null) { target.TakeDamage(damage); }
            if (hit.rigidbody != null) { hit.rigidbody.AddForce(-hit.normal * impactForce ); }

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}