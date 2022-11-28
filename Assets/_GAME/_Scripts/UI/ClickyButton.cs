using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))] public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image       _img;
    [SerializeField] private Sprite      _default, _pressed;
    [SerializeField] private AudioClip   _clickClip;
    private                  Transform   _buttonText;
    private                  AudioSource _audioSource;

    public bool hasText;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (hasText)
            _buttonText = GetComponentInChildren<TextMeshProUGUI>().transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;

        if (hasText)
            _buttonText.position += 2 * Vector3.down;

        _audioSource.PlayOneShot(_clickClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;

        if (hasText)
            _buttonText.position += 2 * Vector3.up;
    }
}