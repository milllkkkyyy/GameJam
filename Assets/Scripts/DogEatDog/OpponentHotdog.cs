using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHotdog : MonoBehaviour
{
    private int maxBites;
    private int currentBites = 0;
    public float speed = 1.5f;

    //Hotdog Images
    public Sprite fullDog;
    SpriteRenderer spriteRenderer;
    public Sprite threeQuarterDog;
    public Sprite halfDog;
    public Sprite quarterDog;


    private void Start()
    {
        maxBites = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fullDog;

    }

    private void Update()
    {
        if (transform.position.y < 1)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        UpdateSprite();
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

    public void UpdateSprite()
    {
        float percentEaten = (float)currentBites / (float)maxBites;
        Debug.Log(percentEaten);
        if (percentEaten <= .25f)
        {
            //set image to 1
            spriteRenderer.sprite = threeQuarterDog;
        }
        else if (percentEaten <= .50f)
        {
            //set image to 2
            spriteRenderer.sprite = halfDog;
        }
        else if (percentEaten <= .75f)
        {
            //set image to 3
            spriteRenderer.sprite = quarterDog;
        }


    }
}
