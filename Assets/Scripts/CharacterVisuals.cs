using System;
using UnityEngine;

public class CharacterVisuals : MonoBehaviour
{
    public CharacterData data;
    public Renderer r;

    private void Start()
    {
        Apply();
    }

    private void Apply()
    {
        r.materials[0].SetColor("_BaseColor", data.shirtColor);
        r.materials[1].SetColor("_BaseColor", data.pantsColor);
        r.materials[2].SetColor("_BaseColor", data.skinColor);
        r.materials[3].SetColor("_BaseColor", data.hairColor);
    }
}