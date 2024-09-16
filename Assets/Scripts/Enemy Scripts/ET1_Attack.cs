using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET1_Attack : MonoBehaviour
{
    EnemyBase baseEnemyScript;

    private void Awake()
    {
        baseEnemyScript = GetComponent<EnemyBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if(baseEnemyScript.distanceToPlayer < 0.3f )
        {
            baseEnemyScript.targetPlayer.GetComponent<HealthAndDamage>().AcceptDamage();
        }
    }
}
