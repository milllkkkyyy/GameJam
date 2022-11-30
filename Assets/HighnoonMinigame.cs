using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighnoonMinigame
{
    public class Pointer
    {
        Vector3 position;
        Quaternion rotation;
        float speed;

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

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public float GetSpeed()
        {
            return this.speed;
        }
    }

    public class Data
    {
        int currentScore;
        int finalScore;

        public void SetCurrentScore(int score)
        {
            this.currentScore = score;
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }

        public void SetFinalScore(int score)
        {
            this.finalScore = score;
        }

        public int GetFinalScore()
        {
            return finalScore;
        }

    }

    public class LostData
    {
        bool won;

        public void SetHasWon(bool won)
        {
            this.won = won;
        }

        public bool GetHasWon()
        {
            return won;
        }
    }

    Pointer pointer = new Pointer();
    LostData lostData = new LostData();
    Data data = new Data();
    int visitedLostData = -1;
    int visitedData = -1;
    int visitedPointer = -1;

    public void SetPointer(Pointer pointer)
    {
        this.pointer = pointer;
    }

    public Pointer GetPointer()
    {
        return this.pointer;
    }

    public void SetData(Data data)
    {
        this.data = data;
    }

    public Data GetData()
    {
        return this.data;
    }

    public void SetLostData(LostData lostData)
    {
        this.lostData = lostData;
    }

    public LostData GetLostData()
    {
        return this.lostData;
    }

    public bool VisitedData()
    {
        visitedData++;
        return visitedData > 0;
    }

    public bool VisitedPointer()
    {
        visitedPointer++;
        return visitedPointer > 0;
    }

    public bool VisitedLostData()
    {
        visitedLostData++;
        return visitedLostData > 0;
    }
}
