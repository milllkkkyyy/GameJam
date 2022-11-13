using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelevisionManager: MonoBehaviour
{

    private static TelevisionManager instance;

    public Animator transition;

    // Currently playable minigames
    string[] minigames = new string[] { "Malik Scene A", "Malik Scene B" };

    string last_scene = "";

    Minigames input;

    float transitionTime = 1f;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            input = new Minigames();
            input.Enable();
        }
    }

    public string GetLastScene()
    {
        return last_scene;
    }

    // Loading levels
    public void ChangeScene(string scene_name)
    {
        StartCoroutine(LoadLevel(scene_name));
    }

    IEnumerator LoadLevel(string scene_name)
    { 
        // Play animation
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load scene
        last_scene = SceneManager.GetActiveScene().name;
        Debug.Log(last_scene);
        SceneManager.LoadScene(scene_name);

    }
}