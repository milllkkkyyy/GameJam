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
}
