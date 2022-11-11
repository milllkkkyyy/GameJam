using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotdogHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hotdogGO;
    [SerializeField] Transform spawnLocation;
    Hotdog hotdog;
    GameObject clone;

    int amountEaten; 

    void Start()
    {
        CreateHotdog();
    }

    void Update()
    {
        if (hotdog.IsFinished())
        {
            amountEaten++;
            DestroyHotdog();
            Debug.Log("Ate 1 Hotdog.");
        }
    }

    void CreateHotdog()
    {
        clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<Hotdog>();
    }

    void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }

    public int GetAmountEaten()
    {
        return amountEaten;
    }
}
