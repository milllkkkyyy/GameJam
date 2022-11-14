using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighNoon : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("High Noon!");
        }
    }
}
