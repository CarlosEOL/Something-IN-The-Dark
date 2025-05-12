using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class UI_Flashlight : MonoBehaviour
{
    [SerializeField]
    FirstPersonController playerController;
    
    [SerializeField]
    Texture2D[] flashlightIcon;
    
    [SerializeField]
    private RawImage flashlightDisplay;
    
    private void Update()
    {
        UpdateFlashlightIcon();
    }
    
    private void UpdateFlashlightIcon()
    {
        if (flashlightDisplay != null && playerController != null && playerController.hasFlashlight)
        {
            int index = playerController._flashlightOn ? 1 : 0;
            flashlightDisplay.texture = flashlightIcon[index];
        }
    }
}
