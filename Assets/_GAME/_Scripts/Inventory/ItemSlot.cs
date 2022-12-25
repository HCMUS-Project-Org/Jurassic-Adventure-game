using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerDownHandler {

    [SerializeField] private Sprite _activeSlotSprite, _inactiveSlotSprite;

    void Update() {
        if (transform.childCount == 0) {
            GetComponent<Image>().sprite = _inactiveSlotSprite;
        } else {
            GetComponent<Image>().sprite = _activeSlotSprite;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            GameObject dropped = eventData.pointerDrag;
            DragAndDrop dragAndDropItem = dropped.GetComponent<DragAndDrop>();
            dragAndDropItem.parentAfterDrag = transform;
        }
    }


    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }   
}

