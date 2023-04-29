using UnityEngine;
using Yarn.Unity;

public class HouseManager : MonoBehaviour
{
    public static HouseManager instance;
    public YarnProject project;
    [YarnNode(nameof(project))]
    public string bothDialogueID;
    [YarnNode(nameof(project))]
    public string deliverDialogueID;
    [YarnNode(nameof(project))]
    public string speakDialogueID;
    
    private HouseController _currentHouse;
    
    private void Awake()
    {
        instance = this;
    }

    public static void InteractWithHouse(HouseController house)
    {
        instance._currentHouse = house;

        if (!instance._currentHouse.wasSpokenTo)
        {
            var dialogue = house.houseData.GetDialogue();
            DialogueController.SetStringVariable("characterName", dialogue.Characters[0].name);
            DialogueController.SetStringVariable("dialogueToTrigger", dialogue.DialogueID);
        }

        var dialogueID = (instance._currentHouse.wasDelivered, instance._currentHouse.wasSpokenTo) switch
        {
            (true, true) => instance.bothDialogueID,
            (false, true) => instance.speakDialogueID,
            (true, false) => instance.deliverDialogueID,
            _ => instance.bothDialogueID
        };
        DialogueController.StartDialogue(dialogueID);
    }

    [YarnCommand("deliver")]
    public void Deliver()
    {
        _currentHouse.wasDelivered = true;
        DialogueController.SetDelivered(instance._currentHouse.houseData.GetMail(),true);
    }

    [YarnCommand("spoken")]
    public void Spoken()
    {
        _currentHouse.wasSpokenTo = true;
    }
    
    [YarnCommand("leave")]
    public void Leave()
    {
        _currentHouse = null;
    }

    public void OnDialogueEnd()
    {
        if(_currentHouse == null) return;

        if (instance._currentHouse.wasDelivered || instance._currentHouse.wasSpokenTo)
        {
            InteractWithHouse(_currentHouse);
        }        
    }
}