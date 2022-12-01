using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    RectTransform rectTransform;
    private void Start()
    {
        //Fetch the RectTransform from the GameObject
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (rectTransform.position.y >= 460)
        {
            //return to menu
            TelevisionManager.instance.ChangeScene("MainMenu", "Change_Start");

        }
        else 
        {
            transform.Translate(Vector2.up * 1.2f * Time.deltaTime);
        }

    }
}
