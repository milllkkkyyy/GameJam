using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMinigame
{
    public class Cloud
    {
        Transform location;
        Vector2 velocity;
    }

    List<Cloud> clouds = new List<Cloud>();

    public class Player
    {
        Transform location;
    }

    public class Data
    {
        float timer;
        float currentScore;
        float totalScore;
    }

    Data data = new Data();

    Player player = new Player();

    void ResetData()
    {
        clouds.Clear();
        data = new Data();
        player = new Player();
    }

    void SaveCloud(Cloud cloud)
    {
        clouds.Add(cloud);
    }

    List<Cloud> LoadClouds()
    {
        return clouds;
    }

    void SetData(Data data)
    {
        this.data = data;
    }

    Data GetData()
    {
        return data;
    }

    Player GetPlayer()
    {
        return player;
    }

    void SetPlayer(Player player)
    {
        this.player = player;
    }
}
