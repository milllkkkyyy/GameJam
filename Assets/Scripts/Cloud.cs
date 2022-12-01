using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public static event System.Action onCloudDeath;
    SpriteRenderer spriteRenderer;
    Vector2 boundary;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        CloudManager.onCloudCreation += InitializeCloud;
        TelevisionManager.onGameChange += SaveCloud;
    }

    void OnDisable()
    {
        CloudManager.onCloudCreation -= InitializeCloud;
        TelevisionManager.onGameChange -= SaveCloud;
    }

    void Update()
    {
        if (CheckXBoundary() || CheckYBoundary())
            ChangeAlpha();
        ShouldDelete();
    }

    void DeleteCloud() => Destroy(gameObject);

    void SaveCloud()
    {
        SkyMinigame.Cloud cloud = new SkyMinigame.Cloud();
        cloud.SaveTransform(this.transform);
        cloud.SetVelocity(GetComponent<Rigidbody2D>().velocity);
        DataManager.sky.SaveCloud(cloud);
    }

    /// <summary>
    /// Initialize the cloud with correct boundary
    /// </summary>
    /// <param name="boundary"></param>
    /// <param name="amountOfClouds"></param>
    void InitializeCloud(Vector2 boundary)
    {
        this.boundary = boundary;
    }

    /// <summary>
    /// Should the cloud be deleted
    /// </summary>
    void ShouldDelete()
    {
        if (spriteRenderer.color.a <= 0.1)
        {
            onCloudDeath?.Invoke();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Changle the alpha of the cloud when it gets near the boundary
    /// </summary>
    void ChangeAlpha()
    {
        Color tmp = spriteRenderer.color;

        tmp.a = Mathf.Lerp(tmp.a, 0, 0.01f);

        spriteRenderer.color = tmp;
    }

    /// <summary>
    /// Check if the cloud is above or below y boundary
    /// </summary>
    /// <returns></returns>
    bool CheckYBoundary()
    {
        return transform.position.y > boundary.y || transform.position.y < -boundary.y;
    }

    /// <summary>
    /// Check if the cloud is right or left of x boundary
    /// </summary>
    /// <returns></returns>
    bool CheckXBoundary()
    {
        return transform.position.x > boundary.x || transform.position.x < -boundary.x;
    }
}
