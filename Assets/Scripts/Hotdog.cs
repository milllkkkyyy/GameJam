using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hotdog : MonoBehaviour
{
    private int maxBites;
    private int currentBites = 0;
    Minigames input; // The input schema we are using
    InputAction action; // Instead of checking KeyCode check InputAction
    
    //need to assign the hot dog to either opponent's bowl or player's bowl
    //private Bowl = PlayerBowlOfHotDogs;
    void Awake()
    {
        input = new Minigames();
        //when the game begins, set which button you need to mash for this hot dog as well
        //as how many bites (maxbites) required to eat the whole dog. this is determined by difficulty (gamevolume)
        this.maxBites = 5;
        //this.maxBites= 5*game.Difficulty

    }

    void OnEnable() => input.Enable();

    void OnDisable() => input.Disable();

    void Start()
    {
        // set which button the hotdog uses.
        action = input.Hotdog.Button1;
    }

    void Update()
    {
        if (action.WasPressedThisFrame())
        {
            Debug.Log("Bite.");
            Bite();
        }
    }

    void Bite()
    {
        currentBites += 1;
    }

    public bool IsFinished()
    {
        return this.currentBites >= maxBites;
    }

    
}
