using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float _originalSize;

    public static HealthBar instance { get; private set; }
    public        Image mask;


    void Awake() {
        instance = this;
    }

    void Start() {
        _originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value) {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _originalSize * value);
    }
}