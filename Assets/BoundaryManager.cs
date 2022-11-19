using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoundaryManager : MonoBehaviour
{
    LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();

        lr.positionCount = 5;
    }

    private void OnEnable()
    {
        CloudManager.onCloudCreation += CreateBoundary;
    }

    private void OnDisable()
    {
        CloudManager.onCloudCreation -= CreateBoundary;
    }

    private void CreateBoundary(Vector2 boundary)
    {
        lr.SetPosition(0, new Vector3(-boundary.x, -boundary.y, 0));

        lr.SetPosition(1, new Vector3(-boundary.x, boundary.y, 0));

        lr.SetPosition(2, new Vector3(boundary.x, boundary.y, 0));

        lr.SetPosition(3, new Vector3(boundary.x, -boundary.y, 0));

        lr.SetPosition(4, new Vector3(-boundary.x, -boundary.y, 0));
    }
}
