using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "HouseData", menuName = "Data/HouseData", order = 0)]
public class HouseData : ScriptableObject
{
    [TextArea] public string address; 
    
    public DialogueData[] dialogues;
    
    public MailData[] mailData;

    [Header("Visuals")]
    public Color roofColor;
    public Color wallColor;
    public Color mailBoxColor;
    
    public DialogueData GetDialogue()
    {
        DialogueData selectedDialogue = null;
        var highestPriority = float.MinValue;
        foreach (var dialogue in dialogues)
        {
            if(dialogue.priority < highestPriority) continue;
            if (!dialogue.CheckCondition()) continue;
            
            selectedDialogue = dialogue;
            highestPriority = Mathf.Max(highestPriority, dialogue.priority);
        }

        return selectedDialogue;
    }
    
    public MailData[] GetMail()
    {
        if(mailData == null) return null;
        var list = mailData.Where(m => m.CheckCondition()).ToList();
        return list?.Count > 0 ? list.ToArray() : null;
    }
}