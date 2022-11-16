using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        if (controller.hasFlashlight == false)
        {
            controller.hasFlashlight = true;
        }
        
        Destroy(gameObject);
    }
}
