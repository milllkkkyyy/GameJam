using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearSkyUI : MonoBehaviour
{
    [SerializeField] GameObject finishedView;
    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] TextMeshProUGUI timeLabel;
    [SerializeField] TextMeshProUGUI amountLeftLabel;

    public static event System.Action<bool> onFinishedRound;

    float amountOfClouds = 0;
    float totalScore = 0;
    float currentScore = 0;

    float timeLeftInSeconds = 5f;
    bool timerOn = false;

    float timeToDisplayView = 2f;
    float displayViewTime = 0f;

    bool finishedGame = false;

    private void OnEnable()
    {
        Dissolve.onCloudDeath += IncreaseScore;
        CloudManager.onNewRound += InitializeUI;
    }

    private void OnDisable()
    {
        Dissolve.onCloudDeath -= IncreaseScore;
        CloudManager.onNewRound -= InitializeUI;
    }

    /// <summary>
    /// Initialize the UI elements
    /// </summary>
    /// <param name="amountOfClouds"></param>
    /// <param name="timeInSeconds"></param>
    private void InitializeUI(float amountOfClouds, float timeInSeconds)
    {
        this.amountOfClouds = amountOfClouds;
        timeLeftInSeconds = timeInSeconds;
        finishedGame = false;
        timerOn = true;
    }

    /// <summary>
    /// Increase the score when a could deletes themselves
    /// </summary>
    private void IncreaseScore()
    {
        if (finishedView.activeSelf)
            return;

        currentScore++;
        HasFinishedGame();
    }

    private void Update()
    {
        UpdateDisplayView();
        UpdateTimer();
        UpdateUI();
    }

    void UpdateDisplayView()
    {
        if (timeLeftInSeconds <= 0 || finishedGame)
        {
            if (displayViewTime > timeToDisplayView)
            {
                displayViewTime = 0;
                finishedView.SetActive(false);
                RebootGame();
            }
            displayViewTime += Time.deltaTime;
        }
    }

    void HasFinishedGame()
    {
        if (currentScore < amountOfClouds)
            return;

        // completed game via score
        finishedGame = true;
        timerOn = false;
        UpdateDispalyViewText(finishedGame);
    }

    void RebootGame()
    {
        if (finishedGame)
            totalScore += currentScore;
        currentScore = 0;
        onFinishedRound?.Invoke(finishedGame);
    }

    void UpdateTimer()
    {
        if (!timerOn)
            return;

        if (timeLeftInSeconds > 0)
        {
            timeLeftInSeconds -= Time.deltaTime;
        }
        else
        {
            timeLeftInSeconds = 0;
            timerOn = false;
            finishedGame = false;
            UpdateDispalyViewText(finishedGame);
        }
    }

    void UpdateDispalyViewText(bool finishedGame)
    {
        string text = finishedGame ? "CLEARED SKY!" : "TIMES UP!";
        finishedView.GetComponent<TextMeshProUGUI>().text = text;
        finishedView.SetActive(true);
    }

    void UpdateUI()
    {
        scoreLabel.text = "Score: " + totalScore;
        amountLeftLabel.text = "Clouds Left: " + (amountOfClouds - currentScore);
        float minutes = Mathf.FloorToInt(timeLeftInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeLeftInSeconds % 60);
        timeLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
