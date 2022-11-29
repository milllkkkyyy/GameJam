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

    public static event System.Action<int> onIntensityStartChange;

    public static event System.Action onGameChange;

    public static event System.Action onGameLoad;

    public static event System.Action onReset;

    private static TelevisionManager instance;

    // Transition related variables

    string[] minigames = new string[] { "Sky", "KK" };

    string last_scene = "";

    float transitionTime = 1f;

    // Knob related variables

    float animationDelayCap = 2f;

    float animationDelayTimer = 0.0f;

    // Intensity related variables

    int intensity = 1;

    float knobIntensityAngle = 0.0f;

    float delayIntensityTimerCap = 1f;

    float delayIntesityTimer = 0.0f;

    bool rotatingIntensityKnob = false;

    // Changing game related variables

    float delayGameChangeTimerCap = 15f;

    float delayGameChangeTimer = 0.0f;

    // Difficulty related variables

    enum Difficulties
    {
        Easy,
        Medium,
        Hard
    }

    Difficulties currentDifficulty = Difficulties.Easy;

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
        delayIntensityTimerCap = Random.Range(10, 20);
    }

    private void Update()
    {
        if (GetCurrentScene() == "MainMenu" || GetCurrentScene() == "Settings")
            return;

        HandleSwitchGame();
        //HandleIntensityKnob();
    }

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
    /// Change the difficulty
    /// </summary>
    private void ChangeDifficulty()
    {
        currentDifficulty = currentDifficulty + 1;
    }

    /// <summary>
    /// Handle the intensity knob
    /// </summary>
    private void HandleIntensityKnob()
    {
        if (!rotatingIntensityKnob)
        {
            if (delayIntesityTimer > delayIntensityTimerCap)
            {
                transition.SetTrigger("Difficulty_start"); // start animation
                delayIntensityTimerCap = Random.Range(10, 20); // reset timer cap
                delayIntesityTimer = 0.0f; // reset timer
                rotatingIntensityKnob = true; // the knob is currently rotation
                ChangeIntensity();
            }
            delayIntesityTimer += Time.deltaTime;
        }
        else
        {
            ChangeRotationOfIntesityKnob();
            if (animationDelayTimer > animationDelayCap)
            {
                rotatingIntensityKnob = false;
                transition.SetTrigger("Difficulty_end");
                animationDelayTimer = 0.0f;
            }
            animationDelayTimer += Time.unscaledDeltaTime;
        }
    }

    /// <summary>
    /// Change the intensity multiplier of the game
    /// </summary>
    private void ChangeIntensity()
    {
        intensity = Random.Range(0, 5);
        
        switch (intensity)
        {
            case 0:
                knobIntensityAngle = 0;
                break;
            case 1:
                knobIntensityAngle = 90;
                break;
            case 2:
                knobIntensityAngle = 180;
                break;

        }
        onIntensityStartChange?.Invoke(intensity);
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
        onGameLoad?.Invoke();
    }

    /// <summary>
    /// Change the rotation of the intensity knob.
    /// </summary>
    private void ChangeRotationOfIntesityKnob()
    {
        float rotation = Mathf.LerpAngle(knobIntensity.transform.rotation.eulerAngles.z, knobIntensityAngle, 0.001f);
        knobIntensity.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
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