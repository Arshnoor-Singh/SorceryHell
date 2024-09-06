using UnityEngine;

public class HealthAndDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damage = 10f;

    delegate void MoreDrama();
    delegate void DamageTakenDelegate(float drama);

    DamageTakenDelegate delegate_DamageTaken;
    MoreDrama Monkey;

    private void Start()
    {
        delegate_DamageTaken = AcceptDamage;
        Monkey = Death;
    }

    public void AcceptDamage(float incomingDamage)
    {
        health = health - incomingDamage;

        if(health < 0 )
        {
            Death();
        }
    }

    private void SomeRandomFunction()
    {

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
