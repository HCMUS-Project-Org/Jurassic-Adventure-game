using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float _healthOriginalSize, _manaOriginalSize;

    public static HealthBar instance { get; private set; }
    public        Image healthMask, manaMask;


    void Awake() {
        instance = this;
    }

    void Start() {
        _healthOriginalSize = healthMask.rectTransform.rect.width;
        _manaOriginalSize = manaMask.rectTransform.rect.width;
    }

    public void SetHealthValue(float value) {
        healthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _healthOriginalSize * value);
    }

    public void SetManaValue(float value) {
        manaMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _manaOriginalSize * value);
    }
}