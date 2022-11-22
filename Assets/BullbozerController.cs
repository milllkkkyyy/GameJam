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

    float intensityMultiplier = 1.0f;

    private void OnEnable()
    {
        CloudManager.onRoundEnd += Reset;
        TelevisionManager.onIntensityStartChange += ChangingIntenityKnob;
        input.Enable();
    }

    private void OnDisable()
    {
        CloudManager.onRoundEnd -= Reset;
        TelevisionManager.onIntensityStartChange -= ChangingIntenityKnob;
        input.Disable();
    }

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

        rb.velocity = transform.right * inputMove * bulldozerSpeed * intensityMultiplier;
    }

    private void Reset()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void ChangingIntenityKnob(float intensity)
    {
        intensityMultiplier = intensity;
    }
}
