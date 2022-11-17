using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] GameObject cloud;

    float boundX = 20f;
    float boundY = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Testing();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Testing()
    {

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                Vector3 randomPos = new Vector3(GetRandomX(), GetRandomY(), 0);
                Quaternion randomRot = GetRandomAngle();
                Instantiate(cloud, randomPos, randomRot);
            }
        }
    }

    float GetRandomX()
    {
        return Random.Range(-boundX, boundY);
    }

    float GetRandomY()
    {
        return Random.Range(-boundY, boundY);
    }

    Quaternion GetRandomAngle()
    {
        return Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    public Vector2 GetBoundary()
    {
        return new Vector2(boundX, boundY);
    }
}
