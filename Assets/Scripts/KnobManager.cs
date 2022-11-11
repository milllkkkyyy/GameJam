using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobManager
{
    int difficulty = 0;

    int intensity = 0;

    public int GetIntesity()
    {
        return intensity;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public void SetIntensity(int intensity)
    {
        this.intensity = intensity;
    }

    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }
}
