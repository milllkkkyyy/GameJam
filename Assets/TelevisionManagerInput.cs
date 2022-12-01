using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionManagerInput : MonoBehaviour
{
    public static event System.Action onEnterSettings;

    Minigames input;

    bool buttonPressed = false;

    private void Awake()
    {
        input = new Minigames();
        input.Enable();
    }

    private void Start()
    {
       input = new Minigames();
       input.Enable();
    }

    private void OnEnable()
    {
        SettingsButtonManger.onExitSettings += UpdateButtonPress;
    }

    private void OnDisable()
    {
        SettingsButtonManger.onExitSettings -= UpdateButtonPress;
        input.Disable();
    }

    void UpdateButtonPress()
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.TelevisionManager.Pause.WasPressedThisFrame() && !buttonPressed && DataManager.inputEnabled)
        {
            onEnterSettings?.Invoke();
            buttonPressed = true;
        }
    }
}
