using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Opponent : MonoBehaviour
{
   // [SerializeField] GameObject hotdogGO;
    //[SerializeField] Transform spawnLocation;
   // Hotdog hotdog;
   // GameObject clone;
    public int amountEaten = 0;
    public float biteSpeed=1;
    public int burpChance=100;
    [SerializeField] Timer time;
    public float currentTime = 0.0f;
    public bool isBurping = false;

    [SerializeField] GameObject hotdogGO;
    [SerializeField] Transform spawnLocation;
    OpponentHotdog hotdog;
    GameObject clone;
    [SerializeField] OpponentScore oponnentScoreTracker;
    public TextMeshProUGUI opponentBurp;
    //sounds
    [SerializeField] AudioSource munch;
    [SerializeField] AudioSource eaten;
    [SerializeField] AudioSource burp;



    private void Start()
    {
        if (DataManager.dog.VisistedOpponent())
        {
            DogMinigame.Opponent opponent = DataManager.dog.GetOpponent();
            amountEaten = opponent.GetAmountEaten();
        }

        //coroutine loop which ends if the timer is 0 or hasnt begun.

        //CreateHotdog();
        opponentBurp = GameObject.Find("OpponentBurpText").GetComponent<TextMeshProUGUI>();
        switch (DataManager.GetDifficulty())
        {
            case 1:
                biteSpeed = .3f;
                burpChance = 10;
                break;
            case 2:
                biteSpeed = 0.2f;
                burpChance = 30;
                break;
            case 3:
                biteSpeed = 0.2f;
                burpChance = 80;
                break;
            default:
                biteSpeed = 0.2f;
                burpChance = 80;
                break;
        }
        CreateHotdog();
    }

    private void OnEnable()
    {
        TelevisionManager.onGameChange += SaveOpponentInformation;
    }

    private void OnDisable()
    {
        TelevisionManager.onGameChange -= SaveOpponentInformation;
    }


    private void Update()
    {
        //if(currentdifficult= difficulty) do this

        if (isBurping == false && time.isActive() && currentTime >= biteSpeed)
        {
            currentTime = 0.0f;
            Bite();
        }
        currentTime += Time.deltaTime;
        if (time.isActive() == false) 
        { 
        DestroyHotdogFinal();
        }
        //else( setbitespeed()

    }


    void CreateHotdog()
    {
        clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<OpponentHotdog>();

    }

    void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }

    void DestroyHotdogFinal()
    {
        Destroy(clone);
    }

    private void Bite()
    {
        int chance = Random.Range(1, burpChance);
        if(chance >= 2)
        {
            //will this work???
           hotdog.Bite();
            munch.Play();
            CheckIfEaten(); 
        }
        else
        {
            Burp();
        }

    }

    private void Burp()
    {
        burp.Play();
        StartCoroutine(BurpWait());
    }

    private void CheckIfEaten()
    {
        if (hotdog.isFinished())
        {
            DestroyHotdog();
            amountEaten++;
            eaten.Play();
            oponnentScoreTracker.SetScore(amountEaten);
        }
    }

    IEnumerator BurpWait()
    {
        opponentBurp.text = "BURP!";
        isBurping = true;
        yield return new WaitForSeconds(1);
        isBurping = false;
        opponentBurp.text = " ";
    }

    //win datamanager.win() 

    public int getScore()
    {
        return amountEaten;
    }

    void SaveOpponentInformation()
    {
        DogMinigame.Opponent data = new DogMinigame.Opponent();
        data.SetAmountEaten(amountEaten);
        DataManager.dog.SetOpponent(data);
    }

}
