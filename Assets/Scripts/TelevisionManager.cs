using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelevisionManager : MonoBehaviour
{
    [SerializeField] Animator transition;

    [SerializeField] GameObject knobIntensity;

    [SerializeField] GameObject knobDifficulty;

    public static event System.Action onGameChange;

    private static TelevisionManager instance;

    // Transition related variables

    string[] minigames = new string[] { "Sky", "KK" };

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

    private void Update()
    {
        if (GetCurrentScene() == "MainMenu" || GetCurrentScene() == "Settings")
            return;

        HandleSwitchGame();
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
    public void ChangeToRandomMinigame()
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
        ChangeScene(notCurrentGame[Random.Range(0, notCurrentGame.Count)]);
    }

    /// <summary>
    /// Change the current scene
    /// </summary>
    /// <param name="scene_name"></param>
    public void ChangeScene(string scene_name)
    {
        StartCoroutine(LoadLevel(scene_name));
    }

    /// <summary>
    /// Load a level using a courotine
    /// </summary>
    /// <param name="scene_name"></param>
    /// <returns>IEnumerator</returns>
    IEnumerator LoadLevel(string scene_name)
    { 
        // Play animation
        transition.SetTrigger("Change_Start");
        // Wait
        yield return new WaitForSecondsRealtime(transitionTime);
        // Load scene
        last_scene = SceneManager.GetActiveScene().name;
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