using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementValues = Vector2.zero;
    private Vector2 lookingValues = Vector2.zero;
    private ParticleSystem muzzleParticleSystem;

    public GameObject bulletPrefab;
    public float playerSpeed = 100f;

    private HealthAndDamage hdComponent;

    public GameObject muzzleLocation;
    public Vector3 hitLocation;

    public bool canShoot = true;
    public float shootingCooldownTimer = 0.5f;

    public static PlayerMovement Instance;

    public float xp;

    public GameObject muzzleFlashVFX;

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

    public void IAPause(InputAction.CallbackContext context) 
    {
        PauseMenuManager.Instance.ToggleGamePause();
    }

    private void Awake()
    {
        if(Instance == null && Instance != this)
        {
            Instance = this;
        }
        hdComponent = GetComponent<HealthAndDamage>();

        GameObject muzzleVFXObject = Instantiate(muzzleFlashVFX, muzzleLocation.transform.position, transform.rotation);
        muzzleParticleSystem = muzzleVFXObject.GetComponent<ParticleSystem>();
        muzzleParticleSystem.Stop();

        muzzleVFXObject.transform.SetParent(transform);
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
        transform.position += new Vector3(movementValues.x * playerSpeed * Time.deltaTime, 0, movementValues.y * playerSpeed * Time.deltaTime);

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
        spawnedBullet = Instantiate(bulletPrefab, muzzleLocation.transform.position, Quaternion.identity);
        spawnedBullet.GetComponent<BaseBulletBehavior>().SetBulletDirection(direction);
        spawnedBullet.GetComponent<BaseBulletBehavior>().bulletDamage = hdComponent.damage;

        canShoot = false;
        StartCoroutine(ShootingCooldown(shootingCooldownTimer));
        
        EmitParams emitParams = new EmitParams();
        emitParams.position = muzzleLocation.transform.position;
        emitParams.startLifetime = 1f;

        muzzleParticleSystem.Emit(emitParams, 2);
    }

    public void PlayerMovementDamageTakenSignal(float damage)
    {
        Debug.Log("Player Damage Signal");
    }

    public void HealthPickUp(float healthAmount)
    {
        if(hdComponent.health >= hdComponent.maxHealth)
        {
            return;
        }
        else
        {
            Debug.Log("Health Picked Up");

            hdComponent.health += healthAmount;
            if(hdComponent.health > hdComponent.maxHealth)
            {
                hdComponent.health = hdComponent.maxHealth;
            }
        }
    }

    public bool CanPickUpHealth()
    {
        if(hdComponent.health >= hdComponent.maxHealth)
        {
            Debug.Log("Cannot Pickup Health");
            return false;
        }
        else
        {
            Debug.Log("Can Pick Up Health");
            return true;
        }
    }

    // Coroutine to destroy the bullet after a specified number of seconds
    IEnumerator ShootingCooldown(float seconds)
    {
        // Waits for the specified number of seconds
        yield return new WaitForSeconds(seconds);

        canShoot = true;
    }
}