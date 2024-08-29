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

    public Vector3 lookDirection;
    public float lookSpeed = 2f;
    public float frameDistance = 100f;

    //public float shootingFrequency = 1f;
    //public float shootTimer = 0f;

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
        Shoot();
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
        lookDirection = transform.forward;
        transform.Translate(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);
    }

    public void Shoot()
    {
        GameObject spawnedBullet;
        spawnedBullet =  Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.Euler(lookDirection));
        spawnedBullet.transform.rotation = Quaternion.Euler(lookDirection);
    }
}