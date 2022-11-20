using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighNoonManager : MonoBehaviour
{

    bool gameOver = false;

    public void GameOver()
    {
        if (gameOver == false) {
            gameOver = true;
            Debug.Log("Game Over");
            Restart();
        };
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
