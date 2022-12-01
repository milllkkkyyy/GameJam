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
    [SerializeField] Opponent opponent;
    [SerializeField] TextMeshProUGUI winText;
    //Sounds
    [SerializeField] AudioSource eaten;





    void Start()
    {
        if (DataManager.dog.VisitedPlayerHandlerData())
        {
            DogMinigame.PlayerHotDogHandlerData data = DataManager.dog.GetPlayerHotDogHandler();
            time.currentTime = data.GetCurrentTime();
            amountEaten = data.GetAmountEaten();
        }

        winText.text = " ";
        winText.color = Color.gray;
        CreateHotdog();
    }

    private void OnEnable()
    {
        TelevisionManager.onGameChange += SaveHandlerInformation;
    }

    private void OnDisable()
    {
        TelevisionManager.onGameChange -= SaveHandlerInformation;
    }

    void Update()
    {
        
        if (hotdog.IsFinished())
        {
            amountEaten++;
            eaten.Play();
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
            EndGame();
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

    private void EndGame()
    {
        if(amountEaten > opponent.getScore())
        {
            winText.color = Color.green;
            //player wins
            winText.text = "YOU WIN!";
        }else if(amountEaten < opponent.getScore())
        {
            //opponent wins
            winText.color = Color.red;
            winText.text = "YOU LOSE";

        }
        else
        {
            //tie game
            winText.color = Color.gray;
            winText.text = "TIE GAME";
        }
    }

    void SaveHandlerInformation()
    {
        DogMinigame.PlayerHotDogHandlerData data = new DogMinigame.PlayerHotDogHandlerData();
        data.SetAmountEaten(amountEaten);
        data.SetCurrentTimer(time.currentTime);
        DataManager.dog.SetPlayerHotDogHandler(data);
    }
}
