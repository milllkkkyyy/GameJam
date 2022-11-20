using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class HighNoon : MonoBehaviour
{
    [SerializeField] CircleCollider2D objectCollider;
    [SerializeField] BoxCollider2D anotherCollider;
    [SerializeField] BoxCollider2D lostCollider;
    [SerializeField] Rotation scriptRotation;


    Minigames input;

    bool won =false;

    private void Awake()
    {
        input = new Minigames(); // Create the new input
        scriptRotation.GetDegreesPerSecond();
    }

    private void OnEnable() => input.Enable(); // Must enable the input

    private void OnDisable() => input.Disable(); // Must disable the input

    private void Update()
    {
        //if the objects are colliding and space is being pressed, High Noon
        if (objectCollider.IsTouching(anotherCollider))
        {
            if (input.HighNoon.Stop.WasPressedThisFrame())
            {
                won = true;
                HNScoreScript.scoreValue += 1;
                scriptRotation.SetDegreesPerSecond(scriptRotation.degreesPerSecond + -20);
                Debug.Log("High Noon");
                scriptRotation.GetDegreesPerSecond();
            }
           
        } 
        if (anotherCollider.IsTouching(lostCollider))
        {
            if (!won)
            {
                FindObjectOfType<HighNoonManager>().GameOver();
            }
            
            
        }

    }
}