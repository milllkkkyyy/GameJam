using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonManger : MonoBehaviour
{
    TelevisionManager manager;

    bool disabled = false;

    void Start() 
    {
        manager = TelevisionManager.instance;
    }

    public void OnReturnGamePress()
    {
        if (disabled)
            return;

        disabled = true;
        Debug.Log("Return Button Pressed.");
        manager.ChangeScene(manager.GetLastScene(), "Change_Start");
        // function calls always need parenthesis 
    }
}
