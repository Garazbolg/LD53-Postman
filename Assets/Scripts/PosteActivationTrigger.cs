using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class PosteActivationTrigger : MonoBehaviour
{
    public static PosteActivationTrigger instance;
    public YarnProject project;
    public MeshRenderer activatorRenderer;
    private bool wasActivated = false;
    private bool wasActivated2 = false;
    [YarnNode(nameof(project))] public string dialogueEndRun;
    public string sceneToLoad;
    

    [ContextMenu("Activate")]
    public void Activate()
    {
        activatorRenderer.material.SetFloat("_CurrentTime",Time.time);
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!wasActivated || wasActivated2)return;
        var car = other.GetComponent<CarController>();
        if (car && car.GetComponent<Rigidbody>().velocity.magnitude < 0.001f)
        {
            Activate();
            wasActivated2 = true;
            DialogueController.StartDialogue(dialogueEndRun);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var car = other.GetComponent<CarController>();
        if (car)
        {
            wasActivated = true;
            wasActivated2 = false;
        }
    }

    [YarnCommand("load")]
    public static void Load()
    {
        SceneManager.LoadScene(instance.sceneToLoad);
    }
}