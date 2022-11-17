using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Vector2 boundary;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        CloudManager manager = GameObject.Find("CloudManager").GetComponent<CloudManager>();
        boundary = manager.GetBoundary();
    }

    void Update()
    {
        if (CheckXBoundary() || CheckYBoundary())
            ChangeAlpha();
        ShouldDelete();
    }

    void ShouldDelete()
    {
        if (spriteRenderer.color.a <= 0)
            Destroy(this);
    }

    void ChangeAlpha()
    {
        Color tmp = spriteRenderer.color;

        tmp.a = Mathf.Lerp(tmp.a, 0, 0.01f);

        spriteRenderer.color = tmp;
    }

    bool CheckYBoundary()
    {
        return transform.position.y > boundary.y || transform.position.y < -boundary.y;
    }

    bool CheckXBoundary()
    {
        return transform.position.x > boundary.x || transform.position.x < -boundary.x;
    }
}
