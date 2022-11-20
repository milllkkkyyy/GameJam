using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNGameWon : MonoBehaviour
{
    public static event System.Action OnHighNoon;

    private void Update()
    {
        OnHighNoon?.Invoke();
    }
}
