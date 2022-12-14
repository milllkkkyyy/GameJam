using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] AudioSource music;

    public static event System.Action<Vector2> onCloudCreation;
    public static event System.Action<float, float, float> onNewRound; /// imagine this as creating an "void onNewRound(float a, float b)"
    public static event System.Action loadPlayerData;
    public static event System.Action onResetData;

    float boundary = 20f;

    private void Start()
    {
        if (DataManager.sky.Visited())
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
            music.time = manager.GetMusicTime();
            onCloudCreation?.Invoke(new Vector2(boundary, boundary));

            // load ui data
            SkyMinigame.UIData uiData = DataManager.sky.GetUIData();
            float cloudAmount = uiData.GetCurrentScore() + cloudData.Count;
            onNewRound?.Invoke(cloudAmount, uiData.GetTime(), uiData.GetCurrentScore());

            loadPlayerData?.Invoke();
            DataManager.sky.ResetData();
        }
        else
        {
            NewRound();
        }
    }

    private void OnEnable()
    {
        TelevisionManager.onGameChange += SaveCloudManager;
        ClearSkyUI.onResetRound += NewRound;
    }

    private void OnDisable()
    {
        TelevisionManager.onGameChange -= SaveCloudManager;
        ClearSkyUI.onResetRound -= NewRound;
    }

    private void SaveCloudManager()
    {
        SkyMinigame.CloudManagerData manager = new SkyMinigame.CloudManagerData();
        manager.SetMusicTime(music.time);
        manager.SetBoundary(boundary);
        DataManager.sky.SetCloudManagerData(manager);
    }

    private void NewRound()
    {
        onResetData?.Invoke();
        int cloudAmount = 0;
        float time = 0;
        switch (DataManager.GetDifficulty())
        {
            case 1:
                cloudAmount = 3;
                boundary = 20f;
                time = 30f;
                break;
            case 2:
                cloudAmount = 6;
                boundary = 25f;
                time = 45f;
                break;
            case 3:
                cloudAmount = 10;
                boundary = 40f;
                time = 60f;
                break;
        }
        CreateRound(cloudAmount);
        onNewRound?.Invoke(cloudAmount * cloudAmount, time, 0);
        DataManager.inputEnabled = true;
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
