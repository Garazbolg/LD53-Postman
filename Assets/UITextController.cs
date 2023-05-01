using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class UITextController : MonoBehaviour
{
    private static UITextController instance;
    public TextMeshProUGUI textUI;
    public float fadeDuration = 1f;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var col = Color.white;
        col.a = 0;
        textUI.color = col;
    }

    [YarnCommand("show_text")]
    public static void ShowText(string text)
    {
        instance.StartCoroutine(instance.CO_ShowText(text));
    }
    
    [YarnCommand("hide_text")]
    public static void HideText()
    {
        instance.StartCoroutine(instance.CO_HideText());
    }
    
    private IEnumerator CO_ShowText(string text)
    {
        textUI.text = text;
        var startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            var color = textUI.color;
            color.a = Mathf.Lerp(0, 1, (Time.time - startTime) / fadeDuration);
            textUI.color = color;
            yield return null;
        }
    }
    
    private IEnumerator CO_HideText()
    {
        var startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            var color = textUI.color;
            color.a = Mathf.Lerp(1, 0, (Time.time - startTime) / fadeDuration);
            textUI.color = color;
            yield return null;
        }
    }
}
