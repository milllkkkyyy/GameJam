using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    TelevisionManager manager;

    bool disabled = false;
    
    void Start() 
    {
        manager = GameObject.Find("TelevistionManager").GetComponent<TelevisionManager>();
    }
    
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
        manager.ChangeScene("Settings");
    }
}
