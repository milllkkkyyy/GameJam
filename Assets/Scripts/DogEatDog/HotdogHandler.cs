using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Windows;

public class HotdogHandler : MonoBehaviour
{
    private bool finishGame = false;
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
    [SerializeField] AudioSource bopbop;
    [SerializeField] AudioSource music;





    void Start()
    {

        
        if (DataManager.dog.VisitedPlayerHandlerData())
        {
            DogMinigame.PlayerHotDogHandlerData data = DataManager.dog.GetPlayerHotDogHandler();
            time.currentTime = data.GetCurrentTime();
            amountEaten = data.GetAmountEaten();
            music.time = data.GetMusicTime();
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
        if(time.isActive() == false && !finishGame)
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
            finishGame = true;
            winText.color = Color.green;
            //player wins
            winText.text = "YOU WIN!";
            DataManager.IncreaseDifficulty();
        }else if(amountEaten < opponent.getScore())
        {
            //opponent wins
            winText.color = Color.red;
            winText.text = "YOU LOSE";
            DataManager.FailedGame(SceneManager.GetActiveScene().name);
            ResetGame();

        }
        else
        {
            //tie game
            winText.color = Color.red;
            winText.text = "TIE GAME";
            DataManager.FailedGame(SceneManager.GetActiveScene().name);
            ResetGame();
        }
        
    }

    void SaveHandlerInformation()
    {
        DogMinigame.PlayerHotDogHandlerData data = new DogMinigame.PlayerHotDogHandlerData();
        data.SetAmountEaten(amountEaten);
        data.SetCurrentTimer(time.currentTime);
        data.SetMusicTime(music.time);
        DataManager.dog.SetPlayerHotDogHandler(data);
    }

    public void ResetGame()
    {
        DataManager.dog = new DogMinigame();
        finishGame = false;
        amountEaten = 0;
        time.RestartTime();
        deletedHotDog = false;
        winText.text = " ";
        opponent.ResetOponnent();
        CreateHotdog();

    }
}
