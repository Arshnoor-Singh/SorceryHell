using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectTest01 : PickableObjectBase
{
    public float healthAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TriggerResponse(Collider _other)
    {
        if(_other.gameObject == PlayerMovement.Instance.gameObject)
        {
            if(PlayerMovement.Instance.CanPickUpHealth() == true)
            {
                willDestroyAfterPickup = true;
                PlayerMovement.Instance.HealthPickUp(healthAmount);
            }
            else
            {
                willDestroyAfterPickup = false;
            }

        }
    }
}
