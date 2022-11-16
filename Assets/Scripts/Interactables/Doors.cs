using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class Doors : Interactable
{
    private readonly int intOpen = Animator.StringToHash("Interact");
    private bool isOpen;
    private bool isIdle = true;
    
    private static bool audioIsPlayed = false;

    private Animator _animator;
    public AudioSource[] AudioOnPlay;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public override void Interact()
    {
        Destroy(AudioOnPlay[0]);

        if (audioIsPlayed == false)
        {
            AudioOnPlay[1].Play();
            AudioOnPlay[2].Play();
            audioIsPlayed = true;
        }

        if (isIdle)
        {
            //Debug.Log("Animation Played");
            isIdle = false;
            if (isOpen)
            {
                Debug.Log("Animation Played - Close");
                _animator.SetTrigger(intOpen);
                isOpen = false;

                isIdle = true;
            }
            else
            {
                Debug.Log("Animation Played - Open");
                _animator.SetTrigger(intOpen);
                isOpen = true;
            }
        }
        
        if (isOpen)
        {
            _animator.SetTrigger(intOpen);
            isOpen = false;

            isIdle = true;
        }
        else
        {
            _animator.SetTrigger(intOpen);
            isOpen = true;
        }
    }
}
