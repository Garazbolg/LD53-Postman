using System;
using UnityEngine;

[Serializable]
public class IntVariableCondition : DialogueCondition
{
    [SerializeReference,SubclassSelector]
    public IntCalculator left;
    [SerializeReference,SubclassSelector]
    public IntCalculator right;
    
    public Comparison comparison;
    
    public override bool CheckCondition()
    {
        return comparison switch
        {
            Comparison.Equal => left.Evaluate() == right.Evaluate(),
            Comparison.NotEqual => left.Evaluate() != right.Evaluate(),
            Comparison.Greater => left.Evaluate() > right.Evaluate(),
            Comparison.GreaterOrEqual => left.Evaluate() >= right.Evaluate(),
            Comparison.Less => left.Evaluate() < right.Evaluate(),
            Comparison.LessOrEqual => left.Evaluate() <= right.Evaluate(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}