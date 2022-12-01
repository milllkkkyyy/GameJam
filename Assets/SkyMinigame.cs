using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMinigame
{
    public class Cloud
    {
        Vector3 position;
        Quaternion rotation;
        Vector2 velocity;

        public void SaveTransform(Transform transform)
        {
            position = transform.position;
            rotation = transform.rotation;
        }

        public void LoadTransform(Transform transform)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }
    }

    List<Cloud> clouds = new List<Cloud>();

    public class Player
    {
        Vector3 position;
        Quaternion rotation;
        Vector2 velocity;

        public void SaveTransform(Transform transform)
        {
            position = transform.position;
            rotation = transform.rotation;
        }

        public void LoadTransform(Transform transform)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }
    }

    public class UIData
    {
        float time;
        float currentScore;

        public void SetTime(float t)
        {
            time = t;
        }

        public void SetCurrentScore(float currentScore)
        {
            this.currentScore = currentScore;
        }

        public float GetTime()
        {
            return time;
        }

        public float GetCurrentScore()
        {
            return currentScore;
        }
    }

    public class CloudManagerData
    {
        float boundary;
        float musicTime;

        public void SetBoundary(float boundary)
        {
            this.boundary = boundary;
        }

        public float GetBoundary()
        {
            return boundary;
        }

        public void SetMusicTime(float time)
        {
            musicTime = time;
        }

        public float GetMusicTime()
        {
            return musicTime;
        }
    }

    CloudManagerData cloudManagerData = new CloudManagerData();

    UIData uiData = new UIData();

    Player player = new Player();

    int visited = -1;

    public void ResetData()
    {
        clouds.Clear();
        cloudManagerData = new CloudManagerData();
        uiData = new UIData();
        player = new Player();
    }

    public void SaveCloud(Cloud cloud)
    {
        clouds.Add(cloud);
    }

    public List<Cloud> LoadClouds()
    {
        return clouds;
    }

    public void SetUIData(UIData data)
    {
        this.uiData = data;
    }

    public UIData GetUIData()
    {
        return uiData;
    }

    public void SetCloudManagerData(CloudManagerData data)
    {
        cloudManagerData = data;
    }

    public CloudManagerData GetCloudManagerData()
    {
        return cloudManagerData;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public bool Visited()
    {
        visited++;
        return visited > 0;
    }
}
