using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] OpponentScore oponentScoreTracker;


    private void Start()
    {
        //coroutine loop which ends if the timer is 0 or hasnt begun.

        //CreateHotdog();
        switch (DataManager.GetDifficulty())
        {
            case 1:
                biteSpeed = 0.5f;
                burpChance = 10;
                break;
            case 2:
                biteSpeed = 1f;
                burpChance = 15;
                break;
            case 3:
                biteSpeed = 1.5f;
                burpChance = 25;
                break;
            case 4:
                biteSpeed = 2;
                burpChance = 100;
                break;
            default:
                biteSpeed = 2.5f;
                burpChance = 100;
                break;
        }
        CreateHotdog();
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

    private void Bite()
    {
        int chance = Random.Range(1, burpChance);
        if(chance >= 2)
        {
            //will this work???
           hotdog.Bite();
        }
        else
        {
            Burp();
        }

    }

    private void Burp()
    {
        StartCoroutine(BurpWait());
    }

    private bool CheckIfEaten()
    {
        return hotdog.isFinished();
    }

    IEnumerator BurpWait()
    {
        isBurping = true;
        yield return new WaitForSeconds(1);
        isBurping = false;
    }

    //win datamanager.win() 

}
