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
        //after creating hotdog, assign it a button value
       // buttonValue.SetButtonValue("W");

    }

    void DestroyHotdog()
    {
        Destroy(clone);
        //Wait .5 seconds between creation
        StartCoroutine(Wait());

        CreateHotdog();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(1);
    }

    public int GetAmountEaten()
    {
        return amountEaten;
    }
}
