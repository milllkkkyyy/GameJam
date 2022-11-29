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
        TelevisionManager.onGameChange += SavePlayerInformation;
        CloudManager.loadPlayerData += LoadPlayerInformation;
        input.Enable();
    }

    private void OnDisable()
    {
        CloudManager.onRoundEnd -= Reset;
        TelevisionManager.onGameChange -= SavePlayerInformation;
        CloudManager.loadPlayerData -= LoadPlayerInformation;
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

    void LoadPlayerInformation()
    {
        SkyMinigame.Player data = DataManager.sky.GetPlayer();
        data.LoadTransform(transform);
        rb.velocity = data.GetVelocity();
    }

    void SavePlayerInformation()
    {
        SkyMinigame.Player data = new SkyMinigame.Player();
        data.SaveTransform(this.transform);
        data.SetVelocity(rb.velocity);
        DataManager.sky.SetPlayer(data);
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

    private void ChangingIntenityKnob(int intensity)
    {
        intensityMultiplier = 1.0f;
        //fix this
    }
}
