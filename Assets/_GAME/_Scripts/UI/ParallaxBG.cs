using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ParallaxBG : MonoBehaviour {

    [SerializeField] private RawImage _img;
    [SerializeField] private Vector2  _offset;

    private void Awake()
    {
        StartCoroutine(ParallaxRoutine());
    }

    private IEnumerator ParallaxRoutine()
    {
        while (true)
        {
            _img.uvRect = new Rect(_img.uvRect.position + _offset * Time.deltaTime, _img.uvRect.size);
            yield return null;
        }
    }

}