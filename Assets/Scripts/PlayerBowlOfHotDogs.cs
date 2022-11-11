using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowlOfHotDogs : Bowl
{
    //container for all hotdogs in this bowl
    //Maybe a way to create hot dogs when the game starts and place them in the bowl and assign them an order value

    void Start()
    {
        
    }
    void Update()
    {
        //look for a player input (AS LONG AS YOU ARENT ON THE BURP COOLDOWN due to messing up a button press)
        //check if player input is the correct input for the current hot dog in the bowl 
        //if it is, +1 hotdog bite, then check if the hotdog has reached its max bites.
        //if current hotdog has reached max bites then move on to the next hot dog. 
        //if you messed up the input activate 'burp' for .5 seconds. during this time the program wont take in player inputs. 
        
    }

    void getHotdoginBowl()
    {

    }

    void checkHotdogAmount()
    {

    }

    
}
