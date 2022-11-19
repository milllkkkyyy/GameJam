using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float degreesPerSecond = -90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }

    public float GetDegreesPerSecond()
    {
        return degreesPerSecond;
    }

    public void SetDegreesPerSecond(float degreesPerSecond)
    {
        this.degreesPerSecond = degreesPerSecond;  
    }
}
