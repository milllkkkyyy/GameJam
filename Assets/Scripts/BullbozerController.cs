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

    private void OnEnable()
    {
        TelevisionManager.onGameChange += SavePlayerInformation;
        CloudManager.loadPlayerData += LoadPlayerInformation;
        input.Enable();
    }

    private void OnDisable()
    {
        TelevisionManager.onGameChange -= SavePlayerInformation;
        CloudManager.loadPlayerData -= LoadPlayerInformation;
        input.Disable();
    }

    private void Awake()
    {
        input = new Minigames();
        rb = GetComponent<Rigidbody2D>();

        switch (DataManager.GetDifficulty())
        {
            case 1:
                bulldozerSpeed = 10f;
                break;
            case 2:
                bulldozerSpeed = 20f;
                break;
            case 3:
                bulldozerSpeed = 30f;
                break;
        }
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

        rb.velocity = transform.right * inputMove * bulldozerSpeed;
    }

    private void Reset()
    {
        transform.position = Vector2.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
