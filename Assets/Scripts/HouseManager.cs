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
    [YarnNode(nameof(project))]
    public string noneDialogueID;
    
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
            var dialogue = house.dialogue;
            DialogueController.SetStringVariable("$characterName", dialogue.Characters[0].name);
            DialogueController.SetStringVariable("$dialogueToTrigger", dialogue.DialogueID);
        }

        var dialogueID = (instance._currentHouse.wasDelivered, instance._currentHouse.wasSpokenTo) switch
        {
            (false, false) => instance.bothDialogueID,
            (true, false) => instance.speakDialogueID,
            (false, true) => instance.deliverDialogueID,
            _ => instance.noneDialogueID,
        };
        DialogueController.StartDialogue(dialogueID);
    }

    [YarnCommand("deliver")]
    public static void Deliver()
    {
        instance._currentHouse.wasDelivered = true;
        var mails = instance._currentHouse.houseData.GetMail();
        if(mails == null) return;
        foreach (var mail in mails)
        {
            DialogueController.SetDelivered(mail,true);
        }
    }

    [YarnCommand("spoken")]
    public static void Spoken()
    {
        instance._currentHouse.wasSpokenTo = true;
    }
    
    [YarnCommand("leave")]
    public static void Leave()
    {
        instance._currentHouse = null;
    }

    public void OnDialogueEnd()
    {
        DialogueController.StopDialogue();
        if(_currentHouse == null) return;
        
        InteractWithHouse(_currentHouse);
    }
}