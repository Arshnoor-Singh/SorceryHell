using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    private EnemyBase baseEnemyScript;
    private bool canAttack;

    public float attackCooldown;
    private float timerValue = 0;

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }

    private void FixedUpdate()
    {
        if (canAttack == false)
        {
            timerValue += 0.02f;
            if (timerValue > attackCooldown)
            {
                timerValue = 0f;
                canAttack = true;
                baseEnemyScript.enemySpeed = 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(baseEnemyScript.distanceToPlayer < 0.3f && canAttack == true)
        {
            float outGoingDamage = GetComponent<HealthAndDamage>().damage;
            PlayerMovement.Instance.gameObject.GetComponent<HealthAndDamage>().AcceptDamage(outGoingDamage);
            canAttack = false;
            baseEnemyScript.enemySpeed = 1;
        }
    }
}
