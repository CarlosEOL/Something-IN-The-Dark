using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public AudioClip _interactSound;
    protected FirstPersonController controller;
    
    public virtual void Interact()
    {
        AudioSource.PlayClipAtPoint(_interactSound, transform.position);
    }

    private void Start()
    {
        controller = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
    }
}
