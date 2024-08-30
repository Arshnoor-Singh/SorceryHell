using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 50f;
    public Rigidbody bulletRigidBody;
    private Vector3 direction;
    public float bulletDamage = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
        collision.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(bulletDamage);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        bulletRigidBody.AddForce(direction * 50f);

        RaycastHit rayHit;
        Debug.DrawLine(transform.position, transform.position + bulletRigidBody.velocity);

        if (Physics.Raycast(transform.position, bulletRigidBody.velocity.normalized, out rayHit, bulletRigidBody.velocity.magnitude * 0.02f))
        {
            rayHit.transform.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(bulletDamage);
            Debug.Log("RayHitDetected");
            Destroy(gameObject);
        }


    }

    public void SetBulletDirection(Vector3 desiredDirection)
    {
        direction = desiredDirection;
    }
}
