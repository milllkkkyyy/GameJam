using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    Camera cam;
    Minigames input;

    float maxZoom = 20f;
    float minZoom = 10f;
    float zoomSpeed = 0.01f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        input = new Minigames();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.ClearSky.Zoom.IsPressed())
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxZoom, zoomSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minZoom, zoomSpeed);
        }
    }
}
