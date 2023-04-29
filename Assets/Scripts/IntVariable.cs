using System;

[Serializable]
public class IntVariable : IntCalculator
{
    public string variableName;

    public override int Evaluate()
    {
        return DialogueController.GetIntVariable(variableName);
    }
}