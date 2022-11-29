using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Windows;

public class HotdogHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hotdogGO;
    [SerializeField] Transform spawnLocation;
    Hotdog hotdog;
    GameObject clone;
    [SerializeField] PlayerScoreTracker playerScoreTracker;
    //[SerializeField] HotDogBite buttonValue;
    int amountEaten =0;
    public bool isPlayer = true;


    


    void Start()
    {
       
        
        CreateHotdog();
        


    }

    void Update()
    {
        
        if (hotdog.IsFinished())
        {
            amountEaten++;
           // PlayerScoreTracker.amountEaten = amountEaten;
            playerScoreTracker.SetScore(amountEaten);
            //why doesnt this working????
           DestroyHotdog();
            Debug.Log("Ate 1 Hotdog.");
            //scoreTracker.SetScore(amountEaten);
            
        }
        
    }

    void CreateHotdog()
    {
        //clone = Instantiate(hotdogGO, spawnLocation,buttonValue);
        clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<Hotdog>();

    }

    void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }


    public int GetAmountEaten()
    {
        return amountEaten;
    }
}
