using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HotdogMinigame : MonoBehaviour
{
   
    HotdogInputManager inputManager;
    HotdogHandler handler;
    
    void Awake()
    {
        inputManager = GetComponent<HotdogInputManager>();
        handler = GetComponent<HotdogHandler>();
        
    }

     void Start()
    {
        handler.CreateHotdog();
        
    }

     void Update()
    {
        if (!handler.IsFinished())
        {
            HandleInput();
        }
        else
        {
            handler.DestroyHotdog();
            Debug.Log("Ate 1 hotdog");
        }

    }

    void HandleInput()
    {
        if (Input.GetKeyDown(handler.GetCurrentButton()))
        {
            handler.Bite();
            Debug.Log("Bite");
        }
    }




}
