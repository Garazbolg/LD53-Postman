using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour
{
    public MeshRenderer renderer;
    public HouseController house;

    [ContextMenu("Activate")]
    public void Activate()
    {
        renderer.material.SetFloat("_CurrentTime",Time.time);
    }

    private void OnTriggerStay(Collider other)
    {
        if(house.CanDeliver) return;
        
        var car = other.GetComponent<CarController>();
        if (car && car.GetComponent<Rigidbody>().velocity.magnitude < 0.001f)
        {
            house.Deliver();
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
