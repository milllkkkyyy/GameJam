using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startingTime;
    public TextMeshProUGUI timerText;
    public float currentTime;
    public bool beginCountdown;
    private void Start()
    {
        startingTime = 10;
        currentTime = startingTime;
        beginCountdown = true;

    }

    private void Update()
    {
        currentTime = beginCountdown ? currentTime -= Time.deltaTime : currentTime;
        if(currentTime < 0)
        {
            //Times Up!
            beginCountdown = false;
            timerText.text = "Times Up!";
        }
        else
        {
            //timerText.text = "Time Left: " + currentTime.ToString();
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text ="Time Left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
       
    }

    public bool isActive()
    {
        return beginCountdown;
    }

}
