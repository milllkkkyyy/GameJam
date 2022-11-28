using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    [SerializeField] GameObject hotdogGO;
    [SerializeField] Transform spawnLocation;
    Hotdog hotdog;
    GameObject clone;
    public int amountEaten = 0;

    private void Start()
    {
        CreateHotdog();
    }

    void CreateHotdog()
    {
        //clone = Instantiate(hotdogGO, spawnLocation,buttonValue);
        clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<Hotdog>();
        //after creating hotdog, assign it a button value
        // buttonValue.SetButtonValue("W");

    }

    void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }


}
