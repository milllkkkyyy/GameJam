using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionManager: MonoBehaviour
{
    KnobManager knobManager = new KnobManager();

    public KnobManager GetKnobManager()
    {
        return knobManager;
    }
}
