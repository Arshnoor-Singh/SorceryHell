using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectBase : MonoBehaviour
{
    public bool willDestroyAfterPickup = true;
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
        TriggerResponse(other);

        if(willDestroyAfterPickup)
        {
            Destroy(gameObject);
        }
    }

    public virtual void TriggerResponse(Collider _other)
    {
        if (_other.gameObject == PlayerMovement.Instance.gameObject)
        {
            Debug.Log("PickUpDetected at base script");
        }
    }
}
