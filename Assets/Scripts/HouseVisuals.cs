using System;
using UnityEngine;

public class HouseVisuals : MonoBehaviour
{
    public HouseData data;
    public Renderer r;
    public Renderer mailRenderer;

    private void Start()
    {
        Apply();
    }

    private void Apply()
    {
        r.materials[0].SetColor("_BaseColor", data.roofColor);
        r.materials[1].SetColor("_BaseColor", data.wallColor);
        mailRenderer.materials[0].SetColor("_BaseColor", data.mailBoxColor);
    }

    private void OnValidate()
    {
        var houseController = GetComponent<HouseController>();
        if(houseController)
            data = houseController.houseData;
    }
}