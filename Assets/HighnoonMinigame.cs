using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighnoonMinigame : MonoBehaviour
{
    public class Pointer
    {
        Vector3 position;
        Quaternion rotation;

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
    }

    public class Data
    {
        int score;

        public void SetScore(int score)
        {
            this.score = score;
        }

        public int GetScore()
        {
            return score;
        }
    }

    Pointer pointer = new Pointer();
    Data data = new Data();

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
}
