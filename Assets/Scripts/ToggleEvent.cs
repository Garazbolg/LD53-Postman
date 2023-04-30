using System;
using UnityEngine;
using UnityEngine.Events;

public class ToggleEvent : MonoBehaviour
{
    public bool startState;
    private bool state;
    public UnityEvent Active;
    public UnityEvent Deactive;

    private void Start()
    {
        state = !startState;
        Toggle();
    }

    public void Toggle()
    {
        state = !state;
        if (state)
            Active.Invoke();
        else
            Deactive.Invoke();
    }
}