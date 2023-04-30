using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputState : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    public string mapToEnable;
    public bool startEnabled = true;
    private void Start()
    {
        SetActive(startEnabled);
    }
    
    public void SetActive(bool active)
    {
        if (active)
        {
            inputActionAsset.FindActionMap(mapToEnable).Enable();
        }
        else
        {
            inputActionAsset.FindActionMap(mapToEnable).Disable();
        }
    }
}
