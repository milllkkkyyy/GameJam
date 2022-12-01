using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScoreTracker : MonoBehaviour
{
    //public int score = 0;
    public TextMesh score;
    public static int amountEaten;
    

    private void Start()
    {
        score = GetComponent<TextMesh>();
        
    }

    public void Update()
    {
        //score.text = "" + amountEaten;
    }
    public void SetScore(int newScore)
    {
        score.text = newScore.ToString();
    }
    
}
