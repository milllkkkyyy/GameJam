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
    }
    private void OnDisable()
    {
        HNUpdateScore.onUpdateScore -= IncreaseRotation;
        HNGameLost.onPlayerLoss -= ResetRotation;
    }
        
    void Update() 
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }
    
    void IncreaseRotation()
    {
        degreesPerSecond += -30;
    }
    
    void ResetRotation()
    {
        degreesPerSecond = -90;
    }
    

}
