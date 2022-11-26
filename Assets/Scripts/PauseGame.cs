using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private static bool paused = false;

    private void Pause()
    {
        Time.timeScale = 0;
        paused = true;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        paused = false;
    }

    public static bool IsPause()
    {
        return paused;
    }
}
