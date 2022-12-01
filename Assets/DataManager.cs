using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static event System.Action onDifficultySwitch;

    public static SkyMinigame sky = new SkyMinigame();

    public static HighnoonMinigame high = new HighnoonMinigame();

    public static DogMinigame dog = new DogMinigame();

    private static int difficulty = 1;

    private static List<string> minigames = new List<string> { "Sky", "KK", "ETHAN" };

    private static Dictionary<string,int> vistedMinigames = new Dictionary<string, int> { {"Sky", -1 }, { "KK", -1 }, { "ETHAN", -1 } };

    private static bool increasingDifficulty = false;

    public static bool inputEnabled = true;

    public static void IncreaseDifficulty()
    {
        /// increase the difficulty
        difficulty++;

        increasingDifficulty = true;

        EraseData();

        /// invoke the transition
        onDifficultySwitch?.Invoke();
    }

    public static void FailedGame(string scene)
    {
        minigames.Remove(scene);

        increasingDifficulty = false;

        if (minigames.Count == 0)
        {
            /// decrease the difficulty
            difficulty--;

            EraseData();

            /// invoke the transition
            onDifficultySwitch?.Invoke();
        }
    }

    private static void EraseData()
    {
        /// erase old data
        sky = new SkyMinigame();
        high = new HighnoonMinigame();
        dog = new DogMinigame();
        minigames = new List<string> { "Sky", "KK", "ETHAN" };
    }

    public static int GetDifficulty()
    {
        return difficulty;
    }

    public static bool IncreasingDifficulty()
    {
        return increasingDifficulty;
    }

    public static bool Visited(string scene)
    {
        vistedMinigames[scene]++;
        return vistedMinigames[scene] > 0;
    }
}