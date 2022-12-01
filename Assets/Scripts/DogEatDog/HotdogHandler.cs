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
    [SerializeField] Opponent opponent;
    [SerializeField] TextMeshProUGUI winText;





    void Start()
    {

        winText.text = " ";
        winText.color = Color.gray;
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
            endGame();
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

    private void endGame()
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
}
