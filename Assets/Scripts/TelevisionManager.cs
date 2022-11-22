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

    public static event System.Action<float> onIntensityStartChange;

    private static TelevisionManager instance;

    // Transition related variables

    string[] minigames = new string[] { "Sky" };

    string last_scene = "";

    float transitionTime = 1f;

    // Knob related variables

    float animationDelayCap = 2f;

    float animationDelayTimer = 0.0f;

    // Intensity related variables

    List<float> intesityMultipliers = new List<float> { 1.0f, 1.5f, 2.0f };

    float currentIntensityValue = 1.0f;

    float knobIntensityAngle = 0.0f;

    float delayIntensityTimerCap = 1f;

    float delayIntesityTimer = 0.0f;

    bool rotatingIntensityKnob = false;

    // Difficulty related variables

    enum Difficulties
    {
        Easy,
        Medium,
        Hard
    }

    const int difficultySize = 3;

    Difficulties currentDifficulty = Difficulties.Easy;

    float knobDifficultyAngle = 0.0f;

    bool rotatingDifficultyKnob = false;

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
        delayIntensityTimerCap = Random.Range(10, 20);
    }

    private void Update()
    {
        if (GetCurrentScene() == "MainMenu" || GetCurrentScene() == "Settings")
            return;

        HandleIntensityKnob();
        HandleDifficultyKnob();
    }

    /// <summary>
    /// Handle the difficulty knob
    /// </summary>
    private void HandleDifficultyKnob()
    {
        if (rotatingDifficultyKnob)
        {
            ChangeRotationOfDifficultyKnob();
            if (animationDelayTimer > animationDelayCap)
            {
                rotatingDifficultyKnob = false;
                transition.SetTrigger("Intensity_end");
                animationDelayTimer = 0.0f;
            }
            animationDelayTimer += Time.unscaledDeltaTime;
        }
    }

    /// <summary>
    /// Change the difficulty
    /// </summary>
    private void ChangeDifficulty()
    {
        currentDifficulty = RandomDifficulty(currentDifficulty);
    }

    /// <summary>
    /// Calculates a random value in a enum, excluding an enum
    /// </summary>
    /// <param name="difficultyToExclude"></param>
    /// <returns>A random enum</returns>
    private Difficulties RandomDifficulty(Difficulties difficultyToExclude)
    {
        int random = Random.Range(0, difficultySize);
        if (random == (int)difficultyToExclude)
        {
            return RandomDifficulty(difficultyToExclude);
        }
        else
        {
            return (Difficulties)random;
        }
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
            delayIntesityTimer += Time.unscaledDeltaTime;
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
        currentIntensityValue = RandomIntensity(currentIntensityValue);
        int intensityIndex = intesityMultipliers.IndexOf(currentIntensityValue);
        switch (intensityIndex)
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
        Debug.Log(currentIntensityValue);
        onIntensityStartChange?.Invoke(currentIntensityValue);
    }

    /// <summary>
    /// Calculates a random value in a list, excluding a value in the list
    /// </summary>
    /// <param name="intensityToExclude"></param>
    /// <returns>a random float</returns>
    private float RandomIntensity(float intensityToExclude)
    {
        int random = Random.Range(0, intesityMultipliers.Count);
        if (Mathf.Abs(intesityMultipliers[random] - intensityToExclude) < 0.1)
        {
            return RandomIntensity(intensityToExclude);
        }
        else
        {
            return intesityMultipliers[random];
        }        
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
        ChangeScene(notCurrentGame[notCurrentGame.Count - 1]);
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
        Debug.Log(last_scene);
        SceneManager.LoadScene(scene_name);

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
    /// Change the rotation of the intensity knob.
    /// </summary>
    private void ChangeRotationOfDifficultyKnob()
    {
        float rotation = Mathf.LerpAngle(knobDifficulty.transform.rotation.eulerAngles.z, knobDifficultyAngle, 0.001f);
        knobDifficulty.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
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