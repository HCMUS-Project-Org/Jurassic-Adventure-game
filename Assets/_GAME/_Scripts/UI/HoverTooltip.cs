using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private GameObject _infoBoard;
     

    // Start is called before the first frame update
    void Start() {
        _infoBoard.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData) {
        _infoBoard.SetActive(true);
    }


    public void OnPointerExit(PointerEventData eventData) {
        _infoBoard.SetActive(false);
    }
}
