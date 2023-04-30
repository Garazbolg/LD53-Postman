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
    public VerticalLayoutGroup container;
    private void Start()
    {
        if (houseData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        AdressText.text = houseData.address;
        var mails = houseData.GetMail();
        if(mails == null) return;
        foreach (var mailData in mails)
        {
            var letter = Instantiate(LetterPrefab, container.transform);
            letter.GetComponent<LetterController>().mailData = mailData;
        }
    }

    private void OnEnable()
    {
        mailIndicator.SetActive(houseData.GetMail() != null);
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
