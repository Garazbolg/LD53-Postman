using System;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

[Serializable]
public class Condition
{
    [HideInInspector] public YarnProject project;
    
    [YarnNode(nameof(project))]
    public string[] RequiredDialogues;
    
    [YarnNode(nameof(project))]
    public string[] ExclusiveDialogues;

    public AgeEnum targetAge;

    public int minDay;
    public int maxDay;
    
    [SerializeReference,SubclassSelector]
    public DialogueCondition[] conditions;
    
    public bool CheckConditions()
    {
        if(GameController.GetCurrentAge() != targetAge)
        {
            return false;
        }
        
        if (GameController.GetCurrentDay() < minDay || GameController.GetCurrentDay() > maxDay)
        {
            return false;
        }
        
        if (RequiredDialogues.Length > 0 && !RequiredDialogues.All(DialogueController.GetVisited))
        {
            return false;
        }
        
        if (ExclusiveDialogues.Length > 0 && ExclusiveDialogues.Any(DialogueController.GetVisited))
        {
            return false;
        }
        
        foreach(var condition in conditions)
        {
            if (!condition.CheckCondition())
                return false;
        }

        return true;
    }
}