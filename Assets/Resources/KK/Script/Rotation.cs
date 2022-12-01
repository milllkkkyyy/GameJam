using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float degreesPerSecond = -90;
    public float speed = -10;

    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += IncreaseRotation;
        HNGameLost.onPlayerLoss += ResetRotation;
        HNScoreScript.onHighNoon += StopRotation;
        TelevisionManager.onGameChange += SavePointer;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseRotation;
        HNGameLost.onPlayerLoss -= ResetRotation;
        HNScoreScript.onHighNoon -= StopRotation;
        TelevisionManager.onGameChange -= SavePointer;
    }

    private void Start()
    {
        if (DataManager.high.VisitedPointer()) // if we have visited this game before
        {
            // get the data from the pointer 
            HighnoonMinigame.Pointer pointer = DataManager.high.GetPointer();
            pointer.LoadTransform(transform);
            degreesPerSecond = pointer.GetRotationInSeconds();
            speed = pointer.GetSpeed();
        }
        else
        {
            switch (DataManager.GetDifficulty())
            {
                case 1:
                    speed = -10;
                    break;
                case 2:
                    speed = -15;
                    break;
                case 3:
                    speed = -20;
                    break;

            }
        }
    }

    void Update() 
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }

    void StopRotation()
    {
        degreesPerSecond = 0.0f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void IncreaseRotation()
    {
        degreesPerSecond += speed;
    }
    
    void ResetRotation()
    {
        degreesPerSecond = -90;
        DataManager.inputEnabled = true;
    }

    void SavePointer()
    {
        HighnoonMinigame.Pointer pointer = new HighnoonMinigame.Pointer();
        pointer.SaveTransform(transform);
        pointer.SetSpeed(speed);
        pointer.SetRotationInSeconds(degreesPerSecond);
        DataManager.high.SetPointer(pointer);
    }

}
