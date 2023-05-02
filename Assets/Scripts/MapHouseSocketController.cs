using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapHouseSocketController : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public HouseData houseData;
    public GameObject houseUI;
    public GameObject LetterPrefab;
    public TMPro.TextMeshProUGUI AdressText;
    public GameObject mailIndicator;
    public GameObject DialogueIndicator;
    public VerticalLayoutGroup container;

    private DialogueData dialogue;
    private IEnumerator Start()
    {
        while (DialogueController.instance == null)
        {
            yield return null;
        }
        if (houseData == null)
        {
            gameObject.SetActive(false);
            yield break;
        }

        AdressText.text = houseData.address;
        dialogue = houseData.GetDialogue();
        var mails = houseData.GetMail();
        if(mails == null) yield break;
        foreach (var mailData in mails)
        {
            var letter = Instantiate(LetterPrefab, container.transform);
            letter.GetComponent<LetterController>().mailData = mailData;
        }
    }

    private void OnEnable()
    {
        mailIndicator.SetActive(houseData.GetMail() != null);
        DialogueIndicator.SetActive(dialogue != null && !DialogueController.GetVisited(dialogue.DialogueID));
        houseUI.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        houseUI.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        houseUI.SetActive(false);
    }
}
