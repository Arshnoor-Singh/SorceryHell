using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementValues = Vector2.zero;
    private Vector2 lookingValues = Vector2.zero;

    public GameObject bulletPrefab;
    public float frameDistance = 100f;

    private HealthAndDamage hdComponent;

    public Vector3 hitLocation;

    public bool canShoot = true;
    public float shootingCooldownTimer = 0.5f;

    public static PlayerMovement Instance;


    public void IAAccelerate(InputAction.CallbackContext context)
    {
        movementValues = context.ReadValue<Vector2>();
    }

    public void IALooking(InputAction.CallbackContext context)
    {
        lookingValues = context.ReadValue<Vector2>();
    }

    public void IAShoot(InputAction.CallbackContext context)
    {
        if (context.started == true)
        {
            Shoot();
        }
    }

    private void Awake()
    {
        if(instance == null && instance != this)
        {
            instance = this;
        }
        hdComponent = GetComponent<HealthAndDamage>();
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // movement
        // The reason I'm using this method is because transform.translate moves the player relative to its position and rotation.
        // This method moves the player relative to its position and does not take rotation into account
        // I find this method to be better during gameplay
        transform.position += new Vector3(movementValues.x * frameDistance * Time.deltaTime, 0, movementValues.y * frameDistance * Time.deltaTime);

        // Check where the mouse is pointing
        ProjectMouseToWorld();
        // Look at the mouse pointer
        transform.LookAt(hitLocation);
    }

    private void ProjectMouseToWorld()
    {
        Ray r = Camera.main.ScreenPointToRay(lookingValues);

        Plane playerPlane = new Plane(Vector3.up, transform.position);

        float entryDistance;

        if (playerPlane.Raycast(r, out entryDistance))
        {
            hitLocation = r.GetPoint(entryDistance);
        }

        Debug.DrawLine(Camera.main.transform.position, hitLocation, Color.blue, 1);
    }

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        GameObject spawnedBullet;
        Vector3 direction = (hitLocation - transform.position).normalized;
        spawnedBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        spawnedBullet.GetComponent<BaseBulletBehavior>().SetBulletDirection(direction);
        spawnedBullet.GetComponent<BaseBulletBehavior>().bulletDamage = hdComponent.damage;

        canShoot = false;
        StartCoroutine(ShootingCooldown(shootingCooldownTimer));
    }

    public void PlayerMovementDamageTakenSignal(float damage)
    {
        Debug.Log("Player Damage Signal");
    }

    // Coroutine to destroy the bullet after a specified number of seconds
    IEnumerator ShootingCooldown(float seconds)
    {
        // Waits for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        canShoot = true;
    }
}