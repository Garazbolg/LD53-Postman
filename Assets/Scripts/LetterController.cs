using UnityEngine;

public class LetterController : MonoBehaviour
{
    public MailData mailData;
    public TMPro.TextMeshProUGUI subjectText;
    public GameObject crossImage;

    private void OnEnable()
    {
        subjectText.text = mailData.subject;
        crossImage.SetActive(DialogueController.GetDelivered(mailData));
    }
}
