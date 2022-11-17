using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullbozerController : MonoBehaviour
{
    Minigames input;

    Rigidbody2D rb;

    float inputMove = 0f;

    float inputRotate = 0f;

    float bulldozerRotation = 5f;

    float bulldozerSpeed = 10f;

    bool zoom = false;

    private void OnDisable() => input.Disable();

    private void OnEnable() => input.Enable();

    private void Awake()
    {
        input = new Minigames();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void GetInput()
    {
        inputMove = input.ClearSky.Move.ReadValue<float>();

        inputRotate = input.ClearSky.Rotate.ReadValue<float>();
    }

    void HandleMovement()
    {
        float rotation = -inputRotate * bulldozerRotation;
        transform.Rotate(Vector3.forward * rotation);

        rb.velocity = transform.right * inputMove * bulldozerSpeed;
    }
}