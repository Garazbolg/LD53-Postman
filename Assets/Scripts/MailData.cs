using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MailData", menuName = "Data/MailData", order = 0)]
public class MailData : ScriptableObject
{
    public string from;
    public string to;
    public string signature;
    public string body;
    public string subject;
    public Sprite[] attachments;

    public bool canRepeat;
    
    public float priority;
    
    public Condition condition;
    
    public bool CheckCondition()
    {
        if(!canRepeat && DialogueController.GetDelivered(this))
        {
            return false;
        }

        return condition.CheckConditions();
    }

    private void OnValidate()
    {
        subject = name;
    }
}