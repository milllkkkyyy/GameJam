using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HNGameLost : MonoBehaviour
{
    [SerializeField] BoxCollider2D lostCollider;
    public static event System.Action onPlayerLoss;

    bool won = false;

    private void Start()
    {
        if (DataManager.high.VisitedLostData())
        {
            won = DataManager.high.GetLostData().GetHasWon();
        }
    }

    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += PlayerWon;
        TelevisionManager.onGameChange += SaveData;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= PlayerWon;
        TelevisionManager.onGameChange -= SaveData;
    }

    void PlayerWon()
    {
        won = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (lostCollider == other)
        {
            if (!won)
            {
                gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -26f);
                DataManager.FailedGame(SceneManager.GetActiveScene().name);
                onPlayerLoss?.Invoke();
            }
            won = false;
        }
        
    }

    void SaveData()
    {
        HighnoonMinigame.LostData lost = new HighnoonMinigame.LostData();
        lost.SetHasWon(won);
        DataManager.high.SetLostData(lost);
    }


}
