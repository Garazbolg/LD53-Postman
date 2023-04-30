using UnityEngine.InputSystem;
using Yarn.Unity;

public class CustomLineView : LineView
{
    public InputActionReference actionForNextLine;

    private void Start()
    {
        actionForNextLine.action.performed += OnNextLine;
    }
    
    private void OnNextLine(InputAction.CallbackContext obj)
    {
        UserRequestedViewAdvancement();
    }
}