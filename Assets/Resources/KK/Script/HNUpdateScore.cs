using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class HNUpdateScore : MonoBehaviour
{
    [SerializeField] CircleCollider2D highNoonCollider;
    [SerializeField] BoxCollider2D pointerCollider;

    Minigames input;

    public static event Action onUpdateScore;
    public AudioSource gunShot;

    // Start is called before the first frame update
    void Awake()
    {
        input = new Minigames(); // Create the new input
    }

    private void OnEnable() => input.Enable(); // Must enable the input

    private void OnDisable() => input.Disable(); // Must disable the input

    // Update is called once per frame
    void Update()
    {
        if (highNoonCollider.IsTouching(pointerCollider))
        {
            if (input.HighNoon.Stop.WasPressedThisFrame())
            {
                gunShot.Play();
                onUpdateScore?.Invoke();
            }

        }
    }
}
