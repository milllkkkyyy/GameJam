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
    }
  

    private void Update()
    {
        //if(currentdifficult= difficulty) do this
        if (time.isActive() && currentTime >= biteSpeed)
        {
            currentTime = 0.0f;
            Bite();
        }
        currentTime += Time.deltaTime;
        //else( setbitespeed()

    }

   
    void CreateHotdog()
    {
       
        //clone = Instantiate(hotdogGO, spawnLocation);
        //hotdog = clone.GetComponent<Hotdog>();

    }

    void DestroyHotdog()
    {
       // Destroy(clone);
        CreateHotdog();
    }

    private void Bite()
    {

    }

    //win datamanager.win() 

}
