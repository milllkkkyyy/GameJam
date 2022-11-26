using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    Camera cam;
    Minigames input;

    float maxZoom = 30f;
    float minZoom = 20f;
    float zoomSpeed = 0.1f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        input = new Minigames();
        input.Enable();
    }

    void Update()
    {
        if (input.ClearSky.Zoom.IsPressed()) // zoom out
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxZoom, zoomSpeed);
        }
        else // zoom back in
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minZoom, zoomSpeed);
        }
    }
}
