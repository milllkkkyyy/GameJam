using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.y >= 100)
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
