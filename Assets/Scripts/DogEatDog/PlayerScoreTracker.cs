using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScoreTracker : MonoBehaviour
{
    //public int score = 0;
    public TextMeshProUGUI score;
    public static int amountEaten;
    

    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        
    }

    public void Update()
    {
        //score.text = "" + amountEaten;
    }
    public void SetScore(int newScore)
    {
        score.SetText(newScore.ToString());
    }
    
}
