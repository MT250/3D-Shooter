using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Rotate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
