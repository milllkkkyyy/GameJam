using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.CodeAnalysis;

public class HNScoreScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI playerScore;

    public static event System.Action onHighNoon;

    int scoreValue = 0;

    int finalScore = 6;

    float uiTimer = 0.0f;

    float uiTimerCap = 1f;

    bool finishedGame = false;

    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += IncreaseScore;
        HNGameLost.onPlayerLoss += ResetScore;
        TelevisionManager.onGameChange += SaveData;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseScore;
        HNGameLost.onPlayerLoss -= ResetScore;
        TelevisionManager.onGameChange -= SaveData;
    }

    private void Start()
    {
        if (DataManager.high.VisitedData()) // if we have visited this game before
        {
            // get the data from the pointer 
            HighnoonMinigame.Data data = DataManager.high.GetData();
            scoreValue = data.GetCurrentScore();
            finalScore = data.GetFinalScore();
        }
        else
        {
            switch (DataManager.GetDifficulty())
            {
                case 1:
                    finalScore = 6;
                    break;
                case 2:
                    finalScore = 12;
                    break;
                case 3:
                    finalScore = 18;
                    break;

            }
        }
    }

    void IncreaseScore()
    {
        scoreValue++;

        // we handle this here so it is only called once.
        if (scoreValue == finalScore) // If score value is 12, game is completed
        {
            DataManager.transitioning = true;
            DataManager.inputEnabled = false;
            playerScore.text = "You Won!"; // change text
            onHighNoon?.Invoke(); // stop the rotation of the pointer
        }
    }
    void ResetScore()
    {
        scoreValue = 0;
        DataManager.inputEnabled = true;
    }

    void Update()
    {
        if (scoreValue < finalScore)
        {
            playerScore.text = "Current Score:  " + scoreValue + " || Final Score: " + finalScore;
        }
        else
        {
            // this is a way to create a timer
            if (uiTimer >= uiTimerCap && !finishedGame)
            {
                uiTimer = 0.0f;
                DataManager.IncreaseDifficulty();
                finishedGame = true;
            }
            uiTimer += Time.deltaTime; // timer += time;
        }
    }

    void SaveData()
    {
        HighnoonMinigame.Data data = new HighnoonMinigame.Data();
        data.SetCurrentScore(scoreValue);
        data.SetFinalScore(finalScore);
        DataManager.high.SetData(data);
    }
}
