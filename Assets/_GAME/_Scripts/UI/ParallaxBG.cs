using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxBG : MonoBehaviour {

    [SerializeField] private RawImage _img;
    [SerializeField] private Vector2  _offset;
    private                  Vector2 _size;


    private void Start() {
        _size = _img.uvRect.size;
    }


    void Update() {
        _img.uvRect = new Rect(_img.uvRect.position + _offset * Time.deltaTime, _size);
    }
}