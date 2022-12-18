using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler {

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition  = this.GetComponent<RectTransform>().anchoredPosition;
        }
    }


    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }   
}

