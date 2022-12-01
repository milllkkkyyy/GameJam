using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingOrder : MonoBehaviour
{
    void Start()
    {
        var parent = transform.parent;

        var parentRenderer = parent.GetComponent<Renderer>();
        var renderer = GetComponent<Renderer>();
        renderer.sortingOrder = parentRenderer.sortingOrder + 1;
    }
}
