using UnityEngine;
using Yarn.Unity;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Data/DialogueData", order = 0)]
public class DialogueData : ScriptableObject
{
    public YarnProject project;
    [YarnNode(nameof(project))]
    public string DialogueID;
    
    public CharacterData[] Characters;
    
    public bool disableDialogueOnLeave;
    public bool charactersLeaveAfterDialogue;
    public bool charactersAppearOnDelivery; // Hidden Dialogue
    public bool startDialogueOnDelivery; // Mandatory Dialogue
    
    public bool canRepeat;
    
    public float priority;

    public Condition condition;

    public bool CheckCondition()
    {
        if(!canRepeat && DialogueController.GetVisited(DialogueID))
        {
            return false;
        }

        return condition.CheckConditions();
    }

    private void OnValidate()
    {
        condition.project = project;
    }
}