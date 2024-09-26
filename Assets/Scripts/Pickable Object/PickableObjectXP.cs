using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectXP : PickableObjectBase
{
    // Start is called before the first frame update
    void Start()
    {
        willDestroyAfterPickup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TriggerResponse(Collider _other)
    {
        if(_other.gameObject == PlayerMovement.Instance.gameObject)
        {
            PlayerMovement.Instance.xp += 5;
        }
    }
}
