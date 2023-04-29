using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivationTrigger : MonoBehaviour
{
    public MeshRenderer activatorRenderer;
    public HouseController house;

    [ContextMenu("Activate")]
    public void Activate()
    {
        activatorRenderer.material.SetFloat("_CurrentTime",Time.time);
    }

    private void OnTriggerStay(Collider other)
    {
        if(!house.CanDeliver) return;
        
        var car = other.GetComponent<CarController>();
        if (car && car.GetComponent<Rigidbody>().velocity.magnitude < 0.001f)
        {
            house.StartDelivering();
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var car = other.GetComponent<CarController>();
        if (car)
        {
            house.Leave();
        }
    }
}
