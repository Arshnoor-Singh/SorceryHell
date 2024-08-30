using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementValues = Vector2.zero;
    Vector2 lookingValues = Vector2.zero;

    public GameObject bulletPrefab;

    public float lookSpeed = 2f;
    public float frameDistance = 100f;

    HealthAndDamage hdComponent;

    public void IAAccelerate(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();
    }

    public void IALooking(InputAction.CallbackContext context)
    {
        lookingValues = context.ReadValue<Vector2>();
        Debug.Log(lookingValues);

        transform.Rotate(transform.up, lookingValues.x * Time.deltaTime * lookSpeed);
    }

    public void IAShoot(InputAction.CallbackContext context)
    {
        if(context.started == true)
        {
            Shoot();
        }
    }

    private void Awake()
    {
        hdComponent = gameObject.GetComponent<HealthAndDamage>();
    }

    void FixedUpdate()
    {
        // 
        //Following lines are for an auto shooter
        //

        //shootTimer += 0.02f;
        //if(shootTimer >= shootingFrequency)
        //{
        //    shootTimer = 0f;
        //    CodeToSpawnBullets;
        //}



    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
    }

    public void Shoot()
    {
        GameObject spawnedBullet;
        Vector3 direction = (transform.forward * 100f) - transform.position;
        spawnedBullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
        spawnedBullet.GetComponent<BaseBulletBehavior>().SetBulletDirection(direction);

        spawnedBullet.GetComponent<BaseBulletBehavior>().bulletDamage = hdComponent.damage;
    }
}