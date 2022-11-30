using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHotdog : MonoBehaviour
{
    private int maxBites;
    private int currentBites = 0;
    public float speed = 1.5f;

    private void Start()
    {
        maxBites = 4;
        
    }

    private void Update()
    {
        if (transform.position.y < 1)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }




    public void Bite()
    {
        currentBites++;

    }

    public int getBites()
    {
        return currentBites;
    }

    public bool isFinished()
    {
        return (currentBites >= maxBites);
    }

    public void setBites(int bites)
    {
        currentBites = bites;
    }

}
