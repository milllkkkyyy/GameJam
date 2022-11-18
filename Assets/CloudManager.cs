using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    public static event System.Action<Vector2> onCloudCreation;
    public static event System.Action<float, float> onNewRound;
    public static event System.Action onRoundEnd;

    float boundX = 20f;
    float boundY = 20f;
    float amountOfCloudsX = 5f;
    float amountOfCloudsY = 5f;

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
        Testing();
        onNewRound?.Invoke(amountOfCloudsX * amountOfCloudsY, 30f);
    }

    /// <summary>
    /// For testing only. Creates a field of clouds.
    /// </summary>
    void Testing()
    {

        for (int x = 0; x < amountOfCloudsX; x++)
        {
            for (int y = 0; y < amountOfCloudsY; y++)
            {
                Vector3 randomPos = new Vector3(GetRandomX(), GetRandomY(), 0);
                Quaternion randomRot = GetRandomAngle();
                Instantiate(cloud, randomPos, randomRot);
            }
        }
        onCloudCreation?.Invoke(new Vector2(boundX, boundY));
    }

    /// <summary>
    /// Get a random x in the boundary
    /// </summary>
    /// <returns></returns>
    float GetRandomX()
    {
        return Random.Range(-boundX, boundY);
    }

    /// <summary>
    /// Get a random y in the boundary
    /// </summary>
    /// <returns></returns>
    float GetRandomY()
    {
        return Random.Range(-boundY, boundY);
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
