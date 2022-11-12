using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelevisionManager: MonoBehaviour
{

    private static TelevisionManager instance;

    // Currently playable minigames
    string[] minigames = new string[] { "Malik Scene A", "Malik Scene B" };

    public Animator transition;

    Minigames input;

    public float transitionTime = 1f;

    private void Start()
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

    // Loading levels
    private void ChangeScene(string scene_name)
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

        SceneManager.LoadScene(scene_name);
    }
}