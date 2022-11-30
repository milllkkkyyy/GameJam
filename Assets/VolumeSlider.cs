using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class VolumeSlider : MonoBehaviour
{
    [SerializeField] GameObject tick;
    [SerializeField] GameObject noTick;
    [SerializeField] TextMeshProUGUI label;

    RectTransform rectTransform;

    void Start()
    {
        //Fetch the RectTransform from the GameObject
        rectTransform = GetComponent<RectTransform>();
        SetVolume50();
    }

    // Update is called once per frame
    void SetVolume50()
    {
        label.text = "Difficulty: Medium";
        int amount = (int)((rectTransform.rect.width / 2f) / 24f);
        for (int i = 0; i < amount; i++)
        {
            Instantiate(tick, transform);
        }
        for (int i = 0; i < amount; i++)
        {
            Instantiate(noTick, transform);
        }
    }
}
