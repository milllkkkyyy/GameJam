using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSkyUI : MonoBehaviour
{
    [SerializeField] GameObject finishedView;
    [SerializeField] GameObject timerView;
    [SerializeField] GameObject leftView;
    [SerializeField] TextMeshProUGUI timeLabel;
    [SerializeField] TextMeshProUGUI amountLeftLabel;

    float amountOfClouds = 0;
    float currentScore = 0;

    float timeLeftInSeconds = 5f;
    bool timerOn = false;

    float timeToDisplayView = 1f;
    float displayViewTime = 0f;

    bool won = false;
    bool startingTransition = false;

    private void OnEnable()
    {
        Cloud.onCloudDeath += IncreaseScore;
        CloudManager.onNewRound += InitializeUI;
        TelevisionManager.onGameChange += SaveUIInformation;
    }

    private void OnDisable()
    {
        Cloud.onCloudDeath -= IncreaseScore;
        CloudManager.onNewRound -= InitializeUI;
        TelevisionManager.onGameChange -= SaveUIInformation;
    }

    private void SaveUIInformation()
    {
        SkyMinigame.UIData data = new SkyMinigame.UIData();
        data.SetCurrentScore(currentScore);
        data.SetTime(timeLeftInSeconds);
        DataManager.sky.SetUIData(data);
    }

    /// <summary>
    /// Initialize the UI elements
    /// </summary>
    /// <param name="amountOfClouds"></param>
    /// <param name="timeInSeconds"></param>
    private void InitializeUI(float amountOfClouds, float timeInSeconds, float currentScore)
    {
        this.currentScore = currentScore;
        this.amountOfClouds = amountOfClouds;
        timeLeftInSeconds = timeInSeconds;
        won = false;
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
        if (startingTransition)
            return;

        if (timeLeftInSeconds <= 0 || won)
        {
            if (displayViewTime > timeToDisplayView)
            {
                displayViewTime = 0;
                if (won)
                {
                    DataManager.IncreaseDifficulty();
                }
                else
                {
                    DataManager.FailedGame(SceneManager.GetActiveScene().name);
                }
                startingTransition = true;
            }
            displayViewTime += Time.deltaTime;
        }
    }

    void HasFinishedGame()
    {
        if (currentScore != amountOfClouds)
            return;

        // completed game via score
        won = true;
        timerOn = false;
        UpdateDispalyViewText(won);
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
            won = false;
            UpdateDispalyViewText(won);
        }
    }

    void UpdateDispalyViewText(bool won)
    {
        string text = won ? "CLEARED SKY!" : "TIMES UP!";
        finishedView.GetComponent<TextMeshProUGUI>().text = text;
        finishedView.SetActive(true);
        leftView.SetActive(false);
        timerView.SetActive(false);
    }

    void UpdateUI()
    {
        if (!leftView.activeSelf && !timerView.activeSelf)
            return;

        amountLeftLabel.text = "Clouds Left: " + (amountOfClouds - currentScore);
        float minutes = Mathf.FloorToInt(timeLeftInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeLeftInSeconds % 60);
        timeLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
