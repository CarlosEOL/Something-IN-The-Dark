using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform plr;
    [SerializeField] private Collider barrier;

    //SerializeField] private FirstPersonController controller;

    private Transform plrTrans;
    private FirstPersonController plrController;

    private bool canTimeStop = true;
    private bool isInTimeStop = false;

    [SerializeField] private TextMeshProUGUI currentObjectiveText;

    private float speed = 2;
    private void Start()
    {
        plr = gameObject.GetComponent<Transform>();
        plrController = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>();
    }

    void Update()
    {
        //currentSceneText.text = SceneLoader.Scene.Game.ToString();

        if (!plrController.hasFlashlight)
        {
            barrier.isTrigger = false;
        }
        else
        {
            barrier.isTrigger = true;
            currentObjectiveText.text = "Explore.";
        }

        if (plr == null)
        {
            Application.Quit();
        }

        if (barrier == null)
        {
            //SceneLoader.Load(SceneLoader.Scene.Corridor);
            //currentSceneText.text = SceneLoader.Scene.Corridor.ToString();
        }

        if (Input.GetKey(KeyCode.LeftControl) && canTimeStop)
        {
            print("IsStoppingTime");

            //saves temp position after time stop
            if (!isInTimeStop)
            {
                plrTrans = plr;

                //set falling to 0 ; limited knowledge on starter controller, didn't work, because object reference failed
                //controller.Gravity = 0;
                
                isInTimeStop = true;
            }
            else if (isInTimeStop)//if is not in time stop, restore original transform; transform does not have a setter?
            {
                plr = plrTrans;

                //Reset gravity;
               // controller.Gravity = -15;
                
                isInTimeStop = false;
            }
            
            //Set time scale = 0 and Start Coroutine in real seconds
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;

            StartCoroutine(WaitForRealSeconds(1));
        }

        if (isInTimeStop)
        {
            //basic movement controls in freezed time, probably won't work since time is stopped. But, it does not use rigid body, therefore...
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("W");
                plr.transform.position += transform.forward * speed * Time.deltaTime; //don't work, game object relies on real time; changed scale time to 0.5
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                
            }
        }
    }
    
    IEnumerator WaitForRealSeconds(float delay)
    {
        canTimeStop = false;
        yield return new WaitForSecondsRealtime(delay);
        canTimeStop = true;
    }
}
