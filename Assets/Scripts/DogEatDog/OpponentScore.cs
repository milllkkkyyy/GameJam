using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpponentScore : MonoBehaviour
{
    public TextMesh score;    

    void Start()
    {
        score = GetComponent<TextMesh>();

    }
    public void SetScore(int newScore)
    {
        score.text = newScore.ToString();
    }



}
