using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DifficultyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] GameObject imageHolder;
    [SerializeField] Sprite won;
    [SerializeField] Sprite lost;

    [SerializeField] AudioSource increasingVoice;
    [SerializeField] AudioSource decreasingVoice;



    void SetGameStatusUI()
    {
        if (DataManager.IncreasingDifficulty())
        {
            imageHolder.GetComponent<Image>().sprite = won;
            label.text = "INCREASING DIFFICULTY";
        }
        else
        {
            imageHolder.GetComponent<Image>().sprite = lost;
            label.text = "DECREASING DIFFICULTY";
        }
    }

    // Update is called once per frame
    void SetDifficultyText()
    {
        switch (DataManager.GetDifficulty())
        {
            case 1:
                label.text = "DIFFICULTY: EASY";
                break;
            case 2:
                label.text = "DIFFICULTY: MEDUIUM";
                break;
            case 3:
                label.text = "DIFFICULTY: HARD";
                break;
        }

    }

    void PlayVoice()
    {
        if (DataManager.IncreasingDifficulty())
        {
            increasingVoice.Play();
        }
        else
        {
            decreasingVoice.Play();
        }

    }
}
