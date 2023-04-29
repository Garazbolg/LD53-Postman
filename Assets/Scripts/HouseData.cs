using UnityEngine;

[CreateAssetMenu(fileName = "HouseData", menuName = "Data/HouseData", order = 0)]
public class HouseData : ScriptableObject
{
    public DialogueData[] dialogues;
    
    public MailData[] mailData;
    
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
    
    public MailData GetMail()
    {
        MailData selectedMail = null;
        var highestPriority = float.MinValue;
        foreach (var mail in mailData)
        {
            if(mail.priority < highestPriority) continue;
            if (!mail.CheckCondition()) continue;
            
            selectedMail = mail;
            highestPriority = Mathf.Max(highestPriority, mail.priority);
        }

        return selectedMail;
    }
}