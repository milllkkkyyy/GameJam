using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] TelevisionManager manager;

    bool disabled = false;

    public void OnExitGamePress()
    {
        if (disabled)
            return;

        disabled = true;
        Debug.Log("Exit Game Button Pressed.");
        Application.Quit();
    }

    public void OnSettingsPress()
    {
        if (disabled)
            return;

        disabled = true;
        Debug.Log("Settings Button Pressed.");
        manager.SetTest("W");
        manager.ChangeScene("Settings");
    }
}
