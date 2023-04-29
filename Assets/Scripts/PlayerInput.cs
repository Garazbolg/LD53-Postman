using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CarController carController;
    
    void Update()
    {
        CarController.CarInput input = new CarController.CarInput();
        input.Throttle = Input.GetKey(KeyCode.W);
        input.Break = Input.GetKey(KeyCode.S);
        input.wheel = Input.GetAxis("Horizontal");
        carController.SetInput(input);
    }
}