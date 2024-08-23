using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 50f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        // Enter Code to Do Damage
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime);
    }
}
