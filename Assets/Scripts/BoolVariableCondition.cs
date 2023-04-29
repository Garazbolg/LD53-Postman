using System;

[Serializable]
public class BoolVariableCondition : DialogueCondition
{
    public string variableName;
    public bool value;
    
    public override bool CheckCondition()
    {
        return DialogueController.GetBoolVariable(variableName) == value;
    }
}