using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hotdog : MonoBehaviour
{
    private int maxBites;
    private int currentBites = 0;
    Minigames input; // The input schema we are using
    InputAction action; // Instead of checking KeyCode check InputAction
    //[SerializeField] private Transform endPos;
    
    //[SerializeField] HotDogBite HotDogButtonValue;
    
    public HotDogBite HotDogButtonValue;
    public float speed = 0.2f;
    private bool firstBite;
    private bool isBurping = false;
    //burptext
    public TextMeshProUGUI playerBurp;

    //Hotdog Images
    public Sprite fullDog;
    SpriteRenderer spriteRenderer;
    public Sprite threeQuarterDog;
    public Sprite halfDog;
    public Sprite quarterDog;

    //sounds
    [SerializeField] AudioSource munch;
    //[SerializeField] AudioSource eaten;
    [SerializeField] AudioSource burp;


    private void Awake()
    {
        input = new Minigames();
    }
    void OnEnable() => input.Enable();

    void OnDisable() => input.Disable();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = fullDog;
        

        playerBurp = GameObject.Find("BurpText").GetComponent<TextMeshProUGUI>();


        HotDogButtonValue = GameObject.Find("HotDogButtonValue").GetComponent<HotDogBite>();
        this.maxBites = 4;
        //this.maxBites= 5*game.Difficulty
        firstBite = false;

        int random = Random.Range(1, 5);
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
        if (isBurping == false)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame) { 
                if (action.WasPressedThisFrame())
                {
                    Debug.Log("Bite.");
                    Bite();
                }
                else
                {
                    Burp();
                    Debug.Log("BURP!");
                }
        }

        }
       
        if (transform.position.y < 1)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    void Bite()
    {
        currentBites += 1;
        munch.Play();
        if (firstBite == false)
        {
            firstBite = true;
            //transform.position = new Vector2(-5f, 1);
            speed = 5f;
            Debug.Log("FirstBite");
            //transform.position = endPos.position;
        }
        HotDogButtonValue.BitePress();
        UpdateSprite();

    }
    public void UpdateSprite()
    {
        float percentEaten = (float)currentBites / (float)maxBites;
        Debug.Log(percentEaten);
        if(percentEaten <= .25f)
        {
            //set image to 1
            spriteRenderer.sprite = threeQuarterDog;
        }else if(percentEaten <=.50f )
        {
            //set image to 2
            spriteRenderer.sprite = halfDog;
        }
        else if (percentEaten <= .75f )
        {
            //set image to 3
            spriteRenderer.sprite =quarterDog;
        }


    }

    public bool IsFinished()
    {
        return this.currentBites >= maxBites;
    }

    public void SetInputAction(InputAction action)
    {
        this.action = action;
    }
    public void SetInput(Minigames input)
    {
        this.input = input;
    }

    private void Burp()
    {
        burp.Play();
        HotDogButtonValue.Burp();
        StartCoroutine(BurpWait());
        //isBurping = true;

    }

    IEnumerator BurpWait()
    {
        playerBurp.text = "BURP!";
        isBurping = true;
        yield return new WaitForSeconds(1);
        isBurping = false;
        playerBurp.text = " ";
    }
    



}
