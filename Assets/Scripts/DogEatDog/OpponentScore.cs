using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpponentScore : MonoBehaviour
{
    
    
    

    public TextMeshProUGUI score;
    

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();

    }
    public void SetScore(int newScore)
    {
        score.SetText(newScore.ToString());
    }



}
