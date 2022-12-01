using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TutorialScreen : MonoBehaviour
{
    public bool displayText = false;

    Minigames input;

    float currentTime = 0.0f;

    float timerCap = 1f;

    void Start()
    {
        input = new Minigames();
        displayText = !(DataManager.Visited(SceneManager.GetActiveScene().name));
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (displayText)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (currentTime >= timerCap)
            {
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
            }
            currentTime += Time.unscaledDeltaTime;
        }
    }
}
