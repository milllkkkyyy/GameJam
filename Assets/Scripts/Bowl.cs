using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    //bowls contain a limit of hotdogs
    //maybe a checker of how many hot dogs are in the bowl
    //
    public int size = 5;
    private int dogsEaten = 0;
    public Hotdog[] hotdogsInBowl;

    public void Start()
    {
        //set array size for how many hotdogs can be in bowl
        hotdogsInBowl = new Hotdog[size];
        this.FillBowl();
    }

    //a function to fill the bowl up with new hot dogs, and giving those hot dogs an order number and input
    private void FillBowl()
    {
       //instantiate new hot dogs?
    }

}
