using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotdog : MonoBehaviour
{
    private int maxBites;
    private int currentBites = 0;
    private KeyCode input = KeyCode.W;
   //need to assign the hot dog to either opponent's bowl or player's bowl
    //private Bowl = PlayerBowlOfHotDogs;
    private void Awake()
    {
        //when the game begins, set which button you need to mash for this hot dog as well
        //as how many bites (maxbites) required to eat the whole dog. this is determined by difficulty (gamevolume)
        this.maxBites = 5;
        //this.maxBites= 5*game.Difficulty

        InitializeInput();

    }
    //set the input button of this hotdog
    private void InitializeInput()
    {
        //get the difficulty setting, and pick from a list of possible buttons according to the difficulty 
    }
    public KeyCode GetButton()
    {
        return this.input;
    }

    public void Bite()
    {
        currentBites += 1;
    }

    public bool IsFinished()
    {
        return this.currentBites >= maxBites;
    }

    
}
