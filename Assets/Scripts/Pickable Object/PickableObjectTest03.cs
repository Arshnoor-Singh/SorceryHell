using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectTest03 : PickableObjectBase
{
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
        Debug.Log("Test 03");
    }

}
