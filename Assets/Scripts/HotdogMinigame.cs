using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotdogMinigame : MonoBehaviour
{
    HotdogHandler handler;

    void Awake()
    {
        handler = GetComponent<HotdogHandler>();
    }
}
