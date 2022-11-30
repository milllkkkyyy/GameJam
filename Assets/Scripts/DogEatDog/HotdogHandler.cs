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
    public bool deletedHotDog = false;
    [SerializeField] Timer time;
    public TextMeshProUGUI displayedButton;



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
        if(time.isActive() == false && !deletedHotDog)
        {

            DestroyHotdogFinal();
            deletedHotDog = true;
            displayedButton.text = " ";
        }
        if(time.isActive() == false)
        {
            displayedButton.text = " ";
        }
        
    }

    void CreateHotdog()
    {
        clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<Hotdog>();

    }

    void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }

    void DestroyHotdogFinal()
    {
        Destroy(clone);
    }


    public int GetAmountEaten()
    {
        return amountEaten;
    }
}
