using System;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public HouseData houseData;
    public bool CanDeliver => (!wasDelivered || !wasSpokenTo) && !DialogueHasStarted;
    public bool DialogueHasStarted = false;
    
    private bool _wasDelivered = false;
    public bool wasDelivered
    {
        get => _wasDelivered;
        set
        {
            _wasDelivered = value;
            mailUI.SetActive(false);
        }
    }
    
    private bool _wasSpokenTo = false;
    public bool wasSpokenTo
    {
        get => _wasSpokenTo;
        set
        {
            _wasSpokenTo = value;
            speakUI.SetActive(false);
        }
    }
    
    public GameObject mailUI;
    public GameObject speakUI;

    private void Start()
    {
        wasSpokenTo = houseData.GetDialogue() == null;
        wasDelivered = houseData.GetMail() == null;
    }

    public void Deliver()
    {
        DialogueHasStarted = true;
        HouseManager.InteractWithHouse(this);
    }

    public void Leave()
    {
        DialogueHasStarted = false;
    }
}