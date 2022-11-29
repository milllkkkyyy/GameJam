using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.CodeAnalysis;

public class HNScoreScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highNoonScore;

    public static event System.Action onHighNoon;

    int scoreValue;

    float uiTimer = 0.0f;

    float uiTimerCap = 10.0f;

    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += IncreaseScore;
        HNGameLost.onPlayerLoss += ResetScore;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseScore;
        HNGameLost.onPlayerLoss -= ResetScore; 
    }

    void IncreaseScore()
    {
        scoreValue++;

        // we handle this here so it is only called once.
        if (scoreValue == 12) // If score value is 12, game is completed
        {
            highNoonScore.text = "You Won!"; // change text
            onHighNoon?.Invoke(); // stop the rotation of the pointer
        }
    }
    void ResetScore()
    {
        scoreValue = 0;
    }

    void Update()
    {
        if (scoreValue < 12)
        {
            highNoonScore.text = "" + scoreValue;
        }
        else
        {
            // this is a way to create a timer
            if (uiTimer >= uiTimerCap) // timer >= 15 seconds, finished timer
            {
                //game won switch games.
            }
            uiTimer += Time.deltaTime; // timer += time;
        }
    }
}
