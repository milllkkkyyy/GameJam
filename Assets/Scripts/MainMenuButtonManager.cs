using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] GameObject televisionPrefab;
    TelevisionManager manager;

    bool disabled = false;
    
    void Start() 
    {
        GameObject tv = GameObject.Find("TelevisionManager(Clone)");

        if (tv == null)
        {
            manager = Instantiate(televisionPrefab, Vector3.zero, Quaternion.identity).GetComponent<TelevisionManager>();
        }
        else
        {
            manager = TelevisionManager.instance;
        }
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
        manager.ChangeScene("Settings", "Change_Start");
    }

    public void OnPlayPress()
    {
        if (disabled)
            return;

        disabled = true;
        Debug.Log("Settings Button Pressed.");
        manager.ChangeToRandomMinigame();
    }
}
