using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueController : MonoBehaviour
{
    private static DialogueController instance;

    public YarnProject project;
    public DialogueRunner runner;
    public VariableStorageBehaviour variableStorage;
    
    private void Awake()
    {
        instance = this;
    }
    
    public static void StartDialogue(string dialogueID)
    {
        instance.runner.StartDialogue(dialogueID);
    }
    
    public static bool GetBoolVariable(string variableName)
    {
        instance.variableStorage.TryGetValue(variableName, out bool value);
        return value;
    }
    
    public static int GetIntVariable(string variableName)
    {
        instance.variableStorage.TryGetValue(variableName, out float value);
        return Mathf.RoundToInt(value);
    }
    
    public static string GetStringVariable(string variableName)
    {
        instance.variableStorage.TryGetValue(variableName, out string value);
        return value;
    }
    
    public static float GetFloatVariable(string variableName)
    {
        instance.variableStorage.TryGetValue(variableName, out float value);
        return value;
    }
    
    public static void SetBoolVariable(string variableName, bool value)
    {
        instance.variableStorage.SetValue(variableName, value);
    }
    
    public static void SetStringVariable(string variableName, string value)
    {
        instance.variableStorage.SetValue(variableName, value);
    }
    
    public static bool GetVisited(string dialogueID)
    {
        var formattedString = $"$Yarn.Internal.FakeVisiting.{dialogueID}";
        instance.variableStorage.TryGetValue(formattedString,out float value);
        return value > 0;
    }

    public static bool GetDelivered(MailData mail)
    {
        var formattedString = $"$Delivered.{mail.name}";
        instance.variableStorage.TryGetValue(formattedString,out bool value);
        return value;
    }

    public static void SetDelivered(MailData mail, bool delivered)
    {
        var formattedString = $"$Delivered.{mail.name}";
        instance.variableStorage.SetValue(formattedString, delivered);
    }

    public static void StopDialogue()
    {
        instance.runner.Stop();
    }
    
    public static YarnProject Project => instance.project;
}