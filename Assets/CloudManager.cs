using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    public static event System.Action<Vector2> onCloudCreation;
    public static event System.Action<float, float> onNewRound;
    public static event System.Action onRoundEnd;

    float boundary = 20f;

    enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    Difficulty difficulty = Difficulty.Easy;

    void Start()
    {
        FinishedRound(false);
    }

    private void OnEnable()
    {
        ClearSkyUI.onFinishedRound += FinishedRound;
    }

    private void OnDisable()
    {
        ClearSkyUI.onFinishedRound -= FinishedRound;
    }

    private void FinishedRound(bool finishedGame)
    {
        onRoundEnd?.Invoke();

        if (finishedGame)
        {
            if (difficulty != Difficulty.Hard)
                difficulty += 1;
        }
        else
        {
            if (difficulty != Difficulty.Easy)
                difficulty -= 1;
        }

        int cloudAmount = 0;

        switch (difficulty)
        {
            case Difficulty.Easy:
                cloudAmount = 5;
                boundary = 20f;
                break;
            case Difficulty.Medium:
                cloudAmount = 7;
                boundary = 40f;
                break;
            case Difficulty.Hard:
                cloudAmount = 10;
                boundary = 50f;
                break;
        }
        CreateRound(cloudAmount);
        onNewRound?.Invoke(cloudAmount * cloudAmount, 30f);
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
