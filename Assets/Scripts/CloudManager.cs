using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    public static event System.Action<Vector2> onCloudCreation;
    public static event System.Action<float, float, float, float> onNewRound; /// imagine this as creating an "void onNewRound(float a, float b)"
    public static event System.Action onRoundEnd; // imagine this as creating a "void onRoundEnd()"
    public static event System.Action loadPlayerData;

    float boundary = 20f;

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    Difficulty difficulty = Difficulty.Easy;

    private void Start()
    {
        if (DataManager.sky.Visited() == 0)
        {
            FinishedRound(false);
        }
        else
        {
            // load cloud data
            List<SkyMinigame.Cloud> cloudData = DataManager.sky.LoadClouds();
            foreach (SkyMinigame.Cloud data in cloudData)
            {
                GameObject clone = Instantiate(cloud);
                data.LoadTransform(clone.transform);
                clone.GetComponent<Rigidbody2D>().velocity = data.GetVelocity();
            }

            // load boundary and cloud manager data
            SkyMinigame.CloudManagerData manager = DataManager.sky.GetCloudManagerData();
            boundary = manager.GetBoundary();
            onCloudCreation?.Invoke(new Vector2(boundary, boundary));

            // load ui data
            SkyMinigame.UIData uiData = DataManager.sky.GetUIData();
            float cloudAmount = uiData.GetCurrentScore() + cloudData.Count;
            onNewRound?.Invoke(cloudAmount, uiData.GetTime(), uiData.GetCurrentScore(), uiData.GetTotalScore());

            loadPlayerData?.Invoke();
        }
        DataManager.sky.ResetData();
    }

    private void OnEnable()
    {
        ClearSkyUI.onFinishedRound += FinishedRound;
        TelevisionManager.onGameChange += SaveCloudManager;
    }

    private void OnDisable()
    {
        ClearSkyUI.onFinishedRound -= FinishedRound;
        TelevisionManager.onGameChange -= SaveCloudManager;
    }

    private void SaveCloudManager()
    {
        SkyMinigame.CloudManagerData manager = new SkyMinigame.CloudManagerData();
        manager.SetBoundary(boundary);
        DataManager.sky.SetCloudManagerData(manager);
    }

    private void FinishedRound(bool finishedGame)
    {
        if (!finishedGame)
        {
            onRoundEnd?.Invoke();

            int cloudAmount = 0;
            switch (difficulty)
            {
                case Difficulty.Easy:
                    cloudAmount = 3;
                    boundary = 10f;
                    break;
                case Difficulty.Medium:
                    cloudAmount = 6;
                    boundary = 20f;
                    break;
                case Difficulty.Hard:
                    cloudAmount = 10;
                    boundary = 40f;
                    break;
            }
            CreateRound(cloudAmount);
            onNewRound?.Invoke(cloudAmount * cloudAmount, 30f, 0, 0);
        }   
    }

    /// <summary>
    /// For testing only. Creates a field of clouds.
    /// </summary>
    void CreateRound(int cloundAmount)
    {

        for (int x = 0; x < cloundAmount; x++)
        {
            for (int y = 0; y < cloundAmount; y++)
            {
                Vector3 randomPos = new Vector3(GetRandomX(), GetRandomY(), 0);
                Quaternion randomRot = GetRandomAngle();
                Instantiate(cloud, randomPos, randomRot);
            }
        }
        // Actions need to invoke inorder to tell other methods to begin.
        onCloudCreation?.Invoke(new Vector2(boundary, boundary));
    }

    /// <summary>
    /// Get a random x in the boundary
    /// </summary>
    /// <returns></returns>
    float GetRandomX()
    {
        return Random.Range(-boundary, boundary);
    }

    /// <summary>
    /// Get a random y in the boundary
    /// </summary>
    /// <returns></returns>
    float GetRandomY()
    {
        return Random.Range(-boundary, boundary);
    }

    /// <summary>
    /// Get a random angle for fun
    /// </summary>
    /// <returns></returns>
    Quaternion GetRandomAngle()
    {
        return Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }
}