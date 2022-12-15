using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomEvent : EventTrigger {
    
    public override void OnPointerEnter(PointerEventData eventData) {
        MouseControl.instance.Clickable();
    }


    public override void OnPointerExit(PointerEventData eventData) {
        MouseControl.instance.Default();
    }
}
