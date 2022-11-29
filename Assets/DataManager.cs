using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static SkyMinigame sky = new SkyMinigame();

    public static HighnoonMinigame high = new HighnoonMinigame();

    private static int difficulty = 0;

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static void IncreaseDifficulty()
    {
        difficulty += 1;
    }
}