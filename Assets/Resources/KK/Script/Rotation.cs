using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float degreesPerSecond = -90;

    private void OnEnable()
    {
        HNUpdateScore.onUpdateScore += IncreaseRotation;
        HNGameLost.onPlayerLoss += ResetRotation;
        HNScoreScript.onHighNoon += StopRotation;
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseRotation;
        HNGameLost.onPlayerLoss -= ResetRotation;
        HNScoreScript.onHighNoon -= StopRotation;
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
        degreesPerSecond += -10;
    }
    
    void ResetRotation()
    {
        degreesPerSecond = -90;
    }
    

}
