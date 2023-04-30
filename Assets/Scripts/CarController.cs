using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public float speed = 10;
    public float breakSpeed = 10;
    public float turnSpeed = 10;
    public float adherence = 0.1f;
    public float stopThreshold = 0.1f;
    public float wheelThreshold = 0.1f;
    
    [Serializable]
    public struct CarInput
    {
        public bool Throttle;
        public bool Break;
        public float wheel;
    }

    private CarInput _currentInput;
    private Rigidbody _rigidbody;

    public void SetInput(CarInput newInput)
    {
        _currentInput = newInput;
    }
    
    public CarInput GetInput()
    {
        return _currentInput;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Add force to the car
        if (_currentInput.Throttle)
        {
            _rigidbody.AddForce(transform.forward * speed);
        }

        // Break
        if (_currentInput.Break)
        {
            _rigidbody.AddForce(transform.forward * -breakSpeed);
        }


        if(!_currentInput.Throttle && !_currentInput.Break && _rigidbody.velocity.magnitude < stopThreshold)
            _rigidbody.velocity = Vector3.zero;
        
        
        // Turn
        if (Mathf.Abs(_currentInput.wheel) > wheelThreshold)
        {
            var rotationScaling = Vector3.Dot(_rigidbody.velocity.normalized, transform.forward);
            _rigidbody.rotation *= Quaternion.Euler(0,
                _currentInput.wheel * turnSpeed * Time.fixedDeltaTime * rotationScaling, 0);
        }

        if (_currentInput.Throttle)
        {
            // Rotate velocity to match the car's forward direction
            var velocity = _rigidbody.velocity;
            var rotation = Quaternion.FromToRotation(velocity.normalized, transform.forward);
            var finalRotation = Quaternion.Slerp(Quaternion.identity, rotation,
                Time.fixedDeltaTime * _rigidbody.velocity.magnitude * adherence);
            _rigidbody.velocity = finalRotation * velocity;
        }
    }
}