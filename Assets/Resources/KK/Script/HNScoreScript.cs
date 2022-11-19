using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HNScoreScript : MonoBehaviour
{
    public TextMeshProUGUI highNoonScore;
    public static int scoreValue;

    public void Start()
    {
        highNoonScore = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        highNoonScore.text = "" + scoreValue;
    }
}
