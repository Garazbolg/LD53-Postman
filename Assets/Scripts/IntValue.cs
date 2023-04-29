using System;

[Serializable]
public class IntValue : IntCalculator
{
    public int value;

    public override int Evaluate()
    {
        return value;
    }
}