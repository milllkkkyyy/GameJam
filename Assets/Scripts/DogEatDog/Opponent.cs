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
    public int difficulty = 1;
    public float biteSpeed=1;
    public int burpChance=100;
    [SerializeField] Timer time;
    public float currentTime = 0.0f;



    private void Start()
    {
        //coroutine loop which ends if the timer is 0 or hasnt begun.
        
        //CreateHotdog();
    }
  

    private void Update()
    {
        if (time.isActive() && currentTime >= biteSpeed)
        {
            currentTime = 0.0f;
            Bite();
        }
        currentTime += Time.deltaTime;

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


}
