using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HotdogHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hotdogGO;
    Hotdog hotdog;
    [SerializeField] Transform spawnLocation;
    GameObject clone;
    
    public void CreateHotdog()
    {
       clone = Instantiate(hotdogGO, spawnLocation);
        hotdog = clone.GetComponent<Hotdog>();

    }

    public KeyCode GetCurrentButton()
    {
        return hotdog.GetButton();
    }

    public void Bite()
    {
        hotdog.Bite();
    }

    public bool IsFinished()
    {
        return hotdog.IsFinished();
    }

    public void DestroyHotdog()
    {
        Destroy(clone);
        CreateHotdog();
    }
    
}
