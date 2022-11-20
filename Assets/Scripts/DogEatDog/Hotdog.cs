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

    //[SerializeField] HotDogBite HotDogButtonValue;
    
    public HotDogBite HotDogButtonValue;

    void Awake()
    {
       
        input = new Minigames();

       


        //when the game begins, set which button you need to mash for this hot dog as well
        //as how many bites (maxbites) required to eat the whole dog. this is determined by difficulty (gamevolume)
        this.maxBites = 5;
        //this.maxBites= 5*game.Difficulty
       

        //When created, move the hotdog up out of the bowl 
        this.moveOutofBowl();


    }

    void OnEnable() => input.Enable();

    void OnDisable() => input.Disable();

    void Start()
    {
        int random = Random.Range(1, 4);
        switch (random)
        {
            case 1:

                action = input.Hotdog.Button1;
                HotDogButtonValue.SetButtonValue("W");
                break;
            case 2:

                action = input.Hotdog.Button2;
                HotDogButtonValue.SetButtonValue("S");
                break;
            case 3:

                action = input.Hotdog.Button3;
                HotDogButtonValue.SetButtonValue("D");
                break;
            case 4:

                action = input.Hotdog.Button4;
                HotDogButtonValue.SetButtonValue("A");
                break;
            default:
                Debug.Log("No button was set");
                action = input.Hotdog.Button1;
                HotDogButtonValue.SetButtonValue("W");
                break;

        }
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

    private void moveOutofBowl()
    {
        //Follow a set path and move the hotdog upwards a few units, gliding. When done, activate the ability to do inputs.

    }

    public void SetInputAction(InputAction action)
    {
        this.action = action;
    }
    public void SetInput(Minigames input)
    {
        this.input = input;
    }



}
