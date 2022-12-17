using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private Image _healthMask, _manaMask;
    
    private float _healthOriginalSize, _manaOriginalSize;

    public HealthBar instance { get; private set; }


    void Awake() {
        instance = this;
    }

    void Start() {
        _healthOriginalSize = _healthMask.rectTransform.rect.width;
        
        if (_manaMask != null) 
            _manaOriginalSize = _manaMask.rectTransform.rect.width;
    }

    public void SetHealthValue(float value) {
        _healthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _healthOriginalSize * value);
    }

    public void SetManaValue(float value) {
        _manaMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _manaOriginalSize * value);
    }
}