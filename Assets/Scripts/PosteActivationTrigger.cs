using UnityEngine;
using Yarn.Unity;

public class PosteActivationTrigger : MonoBehaviour
{
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

    private void OnTriggerStay(Collider other)
    {
        if(!wasActivated || wasActivated2)return;
        var car = other.GetComponent<CarController>();
        if (car && car.GetComponent<Rigidbody>().velocity.magnitude < 0.001f)
        {
            Activate();
            wasActivated2 = true;
            DialogueController.SetStringVariable("$sceneToLoad", sceneToLoad);
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
}