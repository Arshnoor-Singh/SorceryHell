using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public void IAAccelerate(InputAction.CallbackContext context)
    {
        Vector2 moveValues = context.ReadValue<Vector2>();

        transform.Translate(moveValues.x, 0, moveValues.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
