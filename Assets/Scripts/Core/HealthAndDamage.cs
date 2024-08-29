using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;

    public void AcceptDamage(float incomingDamage)
    {
        health = health - incomingDamage;

        if(health < 0 )
        {
            Death();
        }
    }

    public void Death()
    {

    }
}
