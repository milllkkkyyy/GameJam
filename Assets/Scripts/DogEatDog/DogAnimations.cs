using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimations : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite dogNormal;
    public Sprite dogBite;
    public Sprite dogBurp;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = dogNormal;

    }

    public void Bite()
    {
        StartCoroutine(BiteAnim());

    }

    public void Burp()
    {
        StartCoroutine(BurpWait());

    }
    public void ChangeToBurp()
    {
        spriteRenderer.sprite = dogBurp;
    }

    IEnumerator BurpWait()
    {
        spriteRenderer.sprite = dogBurp;
        yield return new WaitForSeconds(1);
        spriteRenderer.sprite = dogNormal;

    }

    IEnumerator BiteAnim()
    {
        spriteRenderer.sprite = dogBite;
        yield return new WaitForSeconds(.2f);
        spriteRenderer.sprite = dogNormal;
    }



}
