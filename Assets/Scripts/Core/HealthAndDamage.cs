using JetBrains.Annotations;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damage = 10f;

    private PlayerMovement movementComponent;
    private PlayerUI uiComponent;

    // Commented out because the actual work is happening from the function
    //public delegate void DEL_OneFloatParameter(float damageTaken);
    //public DEL_OneFloatParameter del_DamageTaken;

    private void Awake()
    {
        movementComponent = GetComponent<PlayerMovement>();
        if(movementComponent != null )
        {
            uiComponent = GetComponent<PlayerUI>();
        }
        else
        {

        }

    }

    private void Start()
    {
        // Commented out because the actual work is happening from the function
        //del_DamageTaken += movementComponent.PlayerMovementDamageTakenSignal;
        //del_DamageTaken += uiComponent.UIDamageTakenSignal; 
    }

    public void AcceptDamage(float incomingDamage)
    {
        // Commented out because the actual work is happening from the function
        //del_DamageTaken?.Invoke(incomingDamage);

        health -= incomingDamage;

        if (movementComponent != null)
        {
            movementComponent.PlayerMovementDamageTakenSignal(incomingDamage);
        }

        if(uiComponent != null) 
        {
            uiComponent.UpdateHealthBar(GetHealthRatio());
        }

        if(health < 0 )
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("Health less than 0. Destroying Game Object");
        Destroy(gameObject);
    }

    public float GetHealthRatio()
    {
        return health / maxHealth;
    }
}
