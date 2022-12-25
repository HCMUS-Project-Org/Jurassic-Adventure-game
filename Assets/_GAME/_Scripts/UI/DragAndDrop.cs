using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    // [SerializeField] private Canvas _canvas;
    // private                  RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Image _image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");

        parentAfterDrag = transform.parent;
        
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        
        _image.raycastTarget = false;
        // _canvasGroup.alpha = .6f;
        // _canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        
        transform.position = Input.mousePosition;;
        // _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");

        transform.SetParent(parentAfterDrag);

        _image.raycastTarget = true;
        // _canvasGroup.alpha = 1f;
        // _canvasGroup.blocksRaycasts = true;
    }


   

}