using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HotDogBite : MonoBehaviour
{
    public TextMeshProUGUI displayedButton;
    public static string  requiredButton;

    private void Start()
    {
        displayedButton = GetComponent<TextMeshProUGUI>();
    }

    //This changes the TextMesh 'button' to the current hotdog's required button press.
    public void Update()
    {
        displayedButton.SetText(requiredButton);
    }

    public void SetButtonValue(string newValue)
    {

        requiredButton = newValue;
    }

    public void BitePress()
    {
        //when you successfully bite one time then flash on screen. 
        StartCoroutine(GreenFlash());
    }

    public void Burp()
    {
        //when you press a wrong buton, you burp. burping means you cannot press any buttons for 1 second. 
        StartCoroutine(RedFlash());
    }

    IEnumerator GreenFlash()
    {
        displayedButton.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        displayedButton.color = Color.white;

    }
    IEnumerator RedFlash()
    {
        displayedButton.color = Color.red;
        yield return new WaitForSeconds(1);
        displayedButton.color = Color.white;

    }
}
