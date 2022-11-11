using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotater : MonoBehaviour
{
    [SerializeField] Transform KnobIntensity;

    [SerializeField] Transform KnobDifficulty;

    TelevisionManager television;

    enum Knob
    {
        NEGATIVE,
        ZERO,
        POSITIVE
    }

    Knob knob = Knob.ZERO;

    double elapsed = 2.0;

    private void Awake()
    {
        television = GetComponentInParent<TelevisionManager>();
    }

    private void Update()
    {
        if (elapsed >= 2)
        {
            elapsed = 0;
            RotateRandomDifficulty();
            RotateRandomInensity();
        }
        elapsed += Time.deltaTime;
    }

    private (int, int) RotateKnob()
    {
        int degrees;
        int value;

        knob = (Knob)Random.Range(0, 3);

        switch (knob)
        {
            case Knob.NEGATIVE:
                degrees = -25;
                value = -1;
                break;
            case Knob.ZERO:
                degrees = 0;
                value = 0;
                break;
            case Knob.POSITIVE:
                degrees = 25;
                value = 1;
                break;
            default:
                degrees = 0;
                value = 0;
                break;
        }

        return (degrees, value);
    }

    private void RotateRandomInensity()
    {
        (int degrees, int intensity) values = RotateKnob();
        //television.GetKnobManager().SetIntensity(values.intensity);
        KnobIntensity.eulerAngles = Vector3.forward * values.degrees;
    }

    private void RotateRandomDifficulty()
    {
        (int degrees, int difficulty) values = RotateKnob();
        //television.GetKnobManager().SetDifficulty(values.difficulty);
        KnobDifficulty.eulerAngles = Vector3.forward * values.degrees;
    }
}
