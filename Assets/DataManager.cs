using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static event System.Action onIncreaseDifficulty;

    public static event System.Action onDecreaseDifficulty;

    public static SkyMinigame sky = new SkyMinigame();

    public static HighnoonMinigame high = new HighnoonMinigame();

    public static DogMinigame dog = new DogMinigame();

    private static int difficulty = 0;

    private static List<string> minigames = new List<string> { "Sky", "KK" };

    public static void IncreaseDifficulty()
    {
        /// increase the difficulty
        difficulty++;

        EraseData();

        /// invoke the transition
        onIncreaseDifficulty?.Invoke();
    }

    public static void FailedGame(string scene)
    {
        minigames.Remove(scene);

        if (minigames.Count == 0)
        {
            /// decrease the difficulty
            difficulty--;

            EraseData();

            /// invoke the transition
            onDecreaseDifficulty?.Invoke();
        }
    }

    private static void EraseData()
    {
        /// erase old data
        sky = new SkyMinigame();
        high = new HighnoonMinigame();
        dog = new DogMinigame();
        minigames = new List<string> { "Sky", "KK" };
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }
}