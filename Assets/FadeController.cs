using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeController : MonoBehaviour
{
    public static FadeController instance;
    public Image fadetarget;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FadeOut();
    }

    [YarnCommand("fadein")]
    public static void FadeIn()
    {
        instance.StartCoroutine(instance.FadeInCoroutine());
    }
    
    [YarnCommand("fadeout")]
    public static void FadeOut()
    {
        instance.StartCoroutine(instance.FadeOutCoroutine());
    }
    
    private IEnumerator FadeInCoroutine()
    {
        var color = fadetarget.color;
        while (color.a < 1)
        {
            color.a += Time.deltaTime;
            fadetarget.color = color;
            yield return null;
        }
    }
    
    private IEnumerator FadeOutCoroutine()
    {
        var color = fadetarget.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            fadetarget.color = color;
            yield return null;
        }
    }
}
