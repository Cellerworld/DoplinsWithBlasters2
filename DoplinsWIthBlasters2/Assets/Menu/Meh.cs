using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Meh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject lightBar;
    [SerializeField]
    GameObject greyischBar;

    public void OnPointerEnter(PointerEventData eventData)
    {
        lightBar.SetActive(true);
        greyischBar.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        lightBar.SetActive(false);
        greyischBar.SetActive(true);
    }

}