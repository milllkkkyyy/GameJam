using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DifficultyText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;

    void SetGameStatusText()
    {
        if (DataManager.IncreasingDifficulty())
        {
            label.text = "INCREASING DIFFICULTY";
        }
        else
        {
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
}
