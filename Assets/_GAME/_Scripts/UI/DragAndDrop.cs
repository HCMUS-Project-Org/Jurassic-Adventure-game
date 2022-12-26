using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private CanvasGroup _canvasGroup;
    private Image _image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        parentAfterDrag = transform.parent;
        
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        
        _image.raycastTarget = false;
    }


    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;;
    }


    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(parentAfterDrag);

        _image.raycastTarget = true;
    }
}