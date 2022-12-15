using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))] public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private Image       _img;
    [SerializeField] private AudioClip   _clickClip;
    private                  Transform   _buttonText ,_buttonImg;
    private                  AudioSource _audioSource;
    
    public Sprite _default, _pressed;
    
    private float positionChange = 2f;

    public bool hasText;
    public bool hasImg;


    void Start() {
        _audioSource = GetComponent<AudioSource>();
 
        if (hasText)
            _buttonText = GetComponentInChildren<TextMeshProUGUI>().transform;

        if (hasImg)
            _buttonImg = GetComponentInChildren<Image>().transform;
    }


    public void OnPointerDown(PointerEventData eventData) {
        _img.sprite = _pressed;

        if (hasText) 
            _buttonText.position += positionChange * Vector3.down;

        if (hasImg)
            _buttonImg.position += positionChange * Vector3.down;

        _audioSource.PlayOneShot(_clickClip);
    }


    public void OnPointerUp(PointerEventData eventData) {
        _img.sprite = _default;

        if (hasText) 
            _buttonText.position += positionChange * Vector3.up;

        if (hasImg)
            _buttonImg.position += positionChange * Vector3.up;
        
    }
}