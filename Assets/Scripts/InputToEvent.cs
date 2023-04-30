using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputToEvent : MonoBehaviour
{
    public InputActionReference action;
    public UnityEvent Performed;

    private void OnEnable()
    {
        action.action.Enable();
        action.action.performed += OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext context)
    {
        Performed.Invoke();
    }
    
    private void OnDisable()
    {
        action.action.Disable();
        action.action.performed -= OnPerformed;
    }
}