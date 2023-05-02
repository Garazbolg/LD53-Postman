using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Yarn.Unity;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource oneShotAudioSource;
    public AudioClip young;
    public AudioClip adult;
    public AudioClip elder;

    public float fadeDuration = 2f;
    public float maxVolume = .6f;
    public float maxOneShotVolume = .7f;
    
    private static MusicController instance;
    
    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        switch (GameController.instance.currentAge)
        {
            case AgeEnum.Young:
                audioSource.clip = young;
                break;
            case AgeEnum.Adult:
                audioSource.clip = adult;
                break;
            case AgeEnum.Elder:
                audioSource.clip = elder;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        audioSource.Play();
        FadeMusicIn();
    }

    [YarnCommand("fade_music_in")]
    public static void FadeMusicIn()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.CO_FadeInVolume());
    }
    
    [YarnCommand("fade_music_out")]
    public static void FadeMusicOut()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.CO_FadeOutVolume());
    }

    public IEnumerator CO_FadeInVolume()
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, maxVolume, currentTime / fadeDuration);
            yield return null;
        }

        yield break;
    }
    
    public IEnumerator CO_FadeOutVolume()
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / fadeDuration);
            yield return null;
        }

        yield break;
    }

    public static void PlayOneShot(AudioClip ac)
    {
        instance.oneShotAudioSource.PlayOneShot(ac, instance.maxOneShotVolume);
    }
}
