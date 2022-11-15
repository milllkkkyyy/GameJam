using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighNoon : MonoBehaviour
{
    [SerializeField] Collider2D objectCollider;
    [SerializeField] Collider2D anotherCollider;

    Minigames input;

    private void Awake()
    {
        input = new Minigames(); // Create the new input
    }

    private void OnEnable() => input.Enable(); // Must enable the input

    private void OnDisable() => input.Disable(); // Must disable the input

    private void Update()
    {
        // if the objects are colliding and space is being pressed, High Noon
        if (objectCollider.IsTouching(anotherCollider))
        {
            if (input.HighNoon.Stop.WasPressedThisFrame())
                Debug.Log("High Noon");
        }
    }
}
