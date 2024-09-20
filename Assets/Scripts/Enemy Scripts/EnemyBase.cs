using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float distanceToPlayer;
    public float enemySpeed;
    public Transform targetPlayer;

    public float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Method 1 - Easy Method
        //transform.LookAt(enemyTarget);

        distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.position);

        transform.position = transform.position + (transform.forward * enemySpeed * Time.deltaTime);

        // Method 2 - Manually doing the Mathematics
        // STEP 1 -  Calculate the direction from the character to the target
        Vector3 direction = targetPlayer.position - transform.position;
        // STEP 2 - Calculate the rotation needed to look in that direction
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        // STEP 3 - Apply the rotation to the character
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
