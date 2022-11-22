using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelevisionManager: MonoBehaviour
{
    [SerializeField] Animator transition;

    [SerializeField] GameObject knobIntensity;

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

    bool rotatingIntesityKnob = false;

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
        delayIntensityTimerCap = Random.Range(3, 5);
    }

    private void Update()
    {
        if (GetCurrentScene() == "MainMenu" || GetCurrentScene() == "Settings")
            return;

        HandleIntensityKnob();
    }

    /// <summary>
    /// Handle the intensity knob
    /// </summary>
    private void HandleIntensityKnob()
    {
        if (!rotatingIntesityKnob)
        {
            if (delayIntesityTimer > delayIntensityTimerCap)
            {
                transition.SetTrigger("Difficulty_start"); // start animation
                delayIntensityTimerCap = Random.Range(3, 5); // reset timer cap
                delayIntesityTimer = 0.0f; // reset timer
                rotatingIntesityKnob = true; // the knob is currently rotation
                ChangeIntensity();
            }
            delayIntesityTimer += Time.unscaledDeltaTime;
        }
        else
        {
            ChangeRotationOfIntesityKnob();
            if (animationDelayTimer > animationDelayCap)
            {
                rotatingIntesityKnob = false;
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
    /// Calculates a random intensity, excluding a float
    /// </summary>
    /// <param name="intensityToExclude"></param>
    /// <returns>a float that is random</returns>
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