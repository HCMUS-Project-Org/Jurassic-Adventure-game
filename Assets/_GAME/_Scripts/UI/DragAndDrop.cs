using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas _canvas;
    private                  RectTransform _rectTransform;
    private                  CanvasGroup _canvasGroup;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");

        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }


   

}