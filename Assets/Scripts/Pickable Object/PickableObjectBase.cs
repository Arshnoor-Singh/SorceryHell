using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PlayerMovement.Instance.gameObject)
        {
            PlayerMovement.Instance.xp += 5;
        }
    }
}
