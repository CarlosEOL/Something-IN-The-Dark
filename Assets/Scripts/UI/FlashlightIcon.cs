using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class FlashlightIcon : MonoBehaviour
{
    [SerializeField] FirstPersonController _plr;
    private Image switchImage;
    private Button button;
    public Sprite[] flashlightSprites = new Sprite[2];

    private void FixedUpdate()
    {
        if (_plr._flashlightOn)
        {
            switchImage.sprite = flashlightSprites[1];
        }
        else
        {
            switchImage.sprite = flashlightSprites[0];
        }
    }

    private void Start()
    {
        switchImage = GetComponent<Image>();
    }
}
