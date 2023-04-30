using System;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public HouseData houseData;
    
    public CharacterVisuals characterPrefab;
    public Transform[] characterSpawnPoints;
    public bool CanDeliver => (!wasDelivered || !wasSpokenTo) && !DialogueHasStarted;
    public bool DialogueHasStarted = false;
    
    private bool _wasDelivered = false;
    private List<GameObject> characterVisuals = new List<GameObject>();
    public bool wasDelivered
    {
        get => _wasDelivered;
        set
        {
            _wasDelivered = value;
            mailUI.SetActive(!value);
        }
    }
    
    private bool _wasSpokenTo = false;
    public bool wasSpokenTo
    {
        get => _wasSpokenTo;
        set
        {
            _wasSpokenTo = value;
            speakUI.SetActive(!value);
        }
    }
    
    public GameObject mailUI;
    public GameObject speakUI;
    public Renderer r;

    private void Start()
    {
        wasSpokenTo = houseData.GetDialogue() == null;
        wasDelivered = houseData.GetMail() == null;
        
        if(wasSpokenTo) return;
        var datas = houseData.GetDialogue().Characters;
        for (var index = 0; index < datas.Length; index++)
        {
            var character = datas[index];
            var t = characterSpawnPoints[index];
            var characterVisuals = Instantiate(characterPrefab,t.position,t.rotation);
            characterVisuals.data = character;
            this.characterVisuals.Add(characterVisuals.gameObject);
        }
    }

    public void StartDelivering()
    {
        DialogueHasStarted = true;
        HouseManager.InteractWithHouse(this);
    }

    public void Leave()
    {
        DialogueHasStarted = false;
        if (wasSpokenTo)
        {
            foreach (var characterVisual in characterVisuals)
            {
                Destroy(characterVisual);
            }
        }
    }
}