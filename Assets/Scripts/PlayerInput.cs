using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public CarController carController;
    
    [Header("Inputs")]
    public InputActionAsset inputActionAsset;
    public string mapToEnable;
    public InputActionReference throttleAction;
    public InputActionReference BreakAction;
    public InputActionReference WheelAction;

    private void Start()
    {
        inputActionAsset.FindActionMap(mapToEnable).Enable();
    }

    void Update()
    {
        carController.SetInput(new CarController.CarInput
        {
            Throttle = throttleAction.action.IsPressed(),
            Break = BreakAction.action.IsPressed(),
            wheel = WheelAction.action.ReadValue<float>()
        });
    }
}