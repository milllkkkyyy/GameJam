using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    RectTransform rectTransform;
    Boolean creditsEnded;
    private void Start()
    {
        creditsEnded = false;
        //Fetch the RectTransform from the GameObject
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (rectTransform.position.y >= 12 && !creditsEnded)
        {
            //return to menu
            TelevisionManager.instance.ChangeScene("MainMenu", "Change_Start");
            creditsEnded = true;
            

        }
        else 
        {
            transform.Translate(Vector2.up * 1.2f * Time.unscaledDeltaTime);
            Debug.Log(rectTransform.position.y);
        }

    }
}
