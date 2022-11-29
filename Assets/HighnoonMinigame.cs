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

    Pointer pointer = new Pointer();
    Data data = new Data();
    int visited = -1;

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

    public bool Visited()
    {
        visited++;
        return visited > 0;
    }
}
