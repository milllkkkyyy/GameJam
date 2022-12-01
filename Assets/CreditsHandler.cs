using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
    [SerializeField] GameObject won;
    [SerializeField] GameObject regular;

    private void Awake()
    {
        DataManager.inputEnabled = false;
    }

    void Start()
    {
        DataManager.inputEnabled = false;
        if (DataManager.gameCompleted)
        {
            won.SetActive(true);
            DataManager.ResetData();
        }
        else
        {
            regular.SetActive(true);
        }
    }

    private void Update()
    {
        if (DataManager.inputEnabled)
            DataManager.inputEnabled = false;
    }
}
