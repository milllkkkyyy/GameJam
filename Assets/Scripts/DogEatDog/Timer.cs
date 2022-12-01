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
       RestartTime();

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

    public void RestartTime()
    {
        if (DataManager.GetDifficulty() == 1)
        {
            startingTime = 45;
        }
        else if (DataManager.GetDifficulty() == 2)
        {
            startingTime = 25;
        }
        else if (DataManager.GetDifficulty() == 3)
        {
            startingTime = 20;
        }

        currentTime = startingTime;
        beginCountdown = true;
    }

}
