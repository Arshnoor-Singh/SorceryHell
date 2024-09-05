using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehavior : MonoBehaviour
{
    // Public variable for bullet speed, editable in the Unity Inspector
    public float bulletSpeed = 1;

    // Private variable to store the bullet's direction
    private Vector3 direction;

    // Public variable for bullet damage, editable in the Unity Inspector
    public float bulletDamage = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        // Starts a coroutine to destroy the bullet after 5 seconds
        StartCoroutine(DestroyAfterSeconds(5f));
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculates the movement vector for this frame
        Vector3 movement = direction * bulletSpeed * Time.deltaTime;

        // Moves the bullet in the calculated direction
        transform.Translate(movement);

        // Declares a variable to store raycast hit information
        RaycastHit rayHit;

        // Calculates the starting point of the raycast (the bullet's previous position)
        Vector3 rayStart = transform.position - movement;

        // Calculates the distance the raycast should check (the distance the bullet moved this frame)
        float rayDistance = movement.magnitude * 1.1f;

        // Creates a new Ray starting from rayStart and going in the bullet's direction
        Ray ray = new Ray(rayStart, direction);

        // Draws a debug line in the Scene view to visualize the bullet's path
        Debug.DrawLine(rayStart, transform.position + movement, Color.yellow);

        // Performs the raycast and checks if it hit something
        if (Physics.Raycast(ray, out rayHit, rayDistance, LayerMask.GetMask("PlayerBulletTarget")))
        {
            // Logs a message if the raycast hit something
            Debug.Log("RayHitDetected");

            // Attempts to get the HealthAndDamage component from the hit object
            HealthAndDamage hitComponentHealth = rayHit.transform.gameObject.GetComponent<HealthAndDamage>();

            // Checks if the hit object has a HealthAndDamage component (presumably an enemy)
            if (hitComponentHealth != null)
            {
                // Logs that an enemy was hit
                Debug.Log("Hit an Enemy");

                // Draws a red debug ray in the Scene view to visualize the hit
                Debug.DrawRay(transform.position, direction, Color.red, 2f);

                // Applies damage to the hit enemy
                hitComponentHealth.AcceptDamage(bulletDamage);

                // Destroys the bullet game object
                Destroy(gameObject);
            }
            else
            {
                // Logs that a wall or non-enemy object was hit
                Debug.Log("Hit a Wall");

                // Draws a magenta debug ray in the Scene view to visualize the hit
                Debug.DrawRay(transform.position, direction, Color.magenta, 2f);

                // Destroys the bullet game object
                Destroy(gameObject);
            }
        }
    }

    // Public method to set the bullet's direction
    public void SetBulletDirection(Vector3 desiredDirection)
    {
        direction = desiredDirection;
    }

    // Coroutine to destroy the bullet after a specified number of seconds
    IEnumerator DestroyAfterSeconds(float seconds)
    {
        // Waits for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        // Destroys the bullet game object
        Destroy(gameObject);
    }
}
