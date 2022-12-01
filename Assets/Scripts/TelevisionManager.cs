using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelevisionManager : MonoBehaviour
{
    [SerializeField] Animator transition;

    public static event System.Action onGameChange;

    public static TelevisionManager instance;

    // Transition related variables

    string[] minigames = new string[] { "Sky", "KK", "ETHAN" };

    string last_scene = "";

    float transitionTime = 1f;

    // Changing game related variables

    float delayGameChangeTimerCap = 15f;

    float delayGameChangeTimer = 0.0f;

    /// <summary>
    /// Check if there are two DontDestoryOnLoad
    /// objects. If so destroy one.
    /// </summary>
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        delayGameChangeTimerCap = Random.Range(5, 10);
    }


    private void OnEnable()
    {
        DataManager.onDifficultySwitch += HandleDifficultySwitch;
        TelevisionManagerInput.onEnterSettings += HandleSettingsSwitch;
    }

    private void OnDisable()
    {
        DataManager.onDifficultySwitch -= HandleDifficultySwitch;
        TelevisionManagerInput.onEnterSettings -= HandleSettingsSwitch;
    }

    private void Update()
    {
        if (GetCurrentScene() == "MainMenu" || GetCurrentScene() == "Settings"  || GetCurrentScene() == "Credits")
            return;

       HandleSwitchGame();
    }

    private void HandleSettingsSwitch()
    {
        onGameChange?.Invoke();
        ChangeScene("Settings", "Change_Start");
    }

    private void HandleDifficultySwitch()
    {
        ChangeScene(GetCurrentScene(), "Difficulty_Start");
    }

    /// <summary>
    /// Handle the switching the game.
    /// </summary>
    private void HandleSwitchGame()
    {
        if (delayGameChangeTimer > delayGameChangeTimerCap)
        {
            delayGameChangeTimer = 0.0f;
            delayGameChangeTimerCap = Random.Range(5, 10);
            onGameChange?.Invoke();
            ChangeToRandomMinigame();
        }
        delayGameChangeTimer += Time.deltaTime;
    }

    /// <summary>
    /// Change the scene to a random minigame
    /// </summary>
    public void ChangeToRandomMinigame(string trigger = "Change_Start")
    {
        // create a new list to fill with currently not played games
        List<string> notCurrentGame = new List<string>();
        foreach (string game in minigames)
        {
            // if a game in the minigame list is not the current scene add it to the list
            if (game != GetCurrentScene())
                notCurrentGame.Add(game);
        }
        // randomly choose a game that is currently not being played
        ChangeScene(notCurrentGame[Random.Range(0, notCurrentGame.Count)], trigger);
    }

    /// <summary>
    /// Change the current scene
    /// </summary>
    /// <param name="scene_name"></param>
    public void ChangeScene(string scene_name, string trigger)
    {
        StartCoroutine(LoadLevel(scene_name, trigger));
    }

    /// <summary>
    /// Load a level using a courotine
    /// </summary>
    /// <param name="scene_name"></param>
    /// <returns>IEnumerator</returns>
    IEnumerator LoadLevel(string scene_name, string trigger)
    { 
        // Play animation
        transition.SetTrigger(trigger);
        // Wait
        yield return new WaitForSecondsRealtime(transitionTime);
        // Load scene
        last_scene = SceneManager.GetActiveScene().name;
        DataManager.inputEnabled = true;
        SceneManager.LoadScene(scene_name);
    }

    /// <summary>
    /// Get the current scene
    /// </summary>
    /// <returns>the current scene name</returns>
    private string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public string GetLastScene()
    {
        return last_scene;
    }

}