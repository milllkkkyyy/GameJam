using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsButtonManger : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider slider;

    public static event System.Action onExitSettings;

    TelevisionManager manager;

    bool disabled = false;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    void Start() 
    {
        manager = TelevisionManager.instance;

        // set the current volume
        float volume = 0.0f;
        audioMixer.GetFloat("volume", out volume);
        slider.value = volume;

        if (manager.GetLastScene() != "MainMenu")
        {
            mainMenuButton.SetActive(true);
        }
    }

    public void OnReturnGamePress()
    {
        if (disabled)
            return;

        disabled = true;
        Debug.Log("Return Button Pressed.");
        manager.ChangeScene(manager.GetLastScene(), "Change_Start");
        onExitSettings?.Invoke();
        // function calls always need parenthesis 
    }

    public void OnReturnToMainMenuPressed()
    {
        if (disabled)
            return;

        disabled = true;
        manager.ChangeScene("MainMenu", "Change_Start");
        DataManager.ResetData();
    }
}

