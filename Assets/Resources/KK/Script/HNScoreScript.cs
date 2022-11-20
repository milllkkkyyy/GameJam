using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.CodeAnalysis;

public class HNScoreScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highNoonScore;
    int scoreValue;
    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += IncreaseScore;
        HNGameLost.onPlayerLoss += ResetScore;
        HNGameWon.OnHighNoon += ScoreReached;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseScore;
        HNGameLost.onPlayerLoss -= ResetScore; 
        HNGameWon.OnHighNoon -= ScoreReached;
    }

    void IncreaseScore()
    {
        scoreValue++;
    }
    void ResetScore()
    {
        scoreValue = 0;
    }
    void ScoreReached()
    {
        if (scoreValue != 12)
        {
            highNoonScore.text = "You Won!"; 
        }
    }

    void Update()
    {
        highNoonScore.text = "" + scoreValue;
    }
}
