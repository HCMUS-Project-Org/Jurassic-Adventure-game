using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] private GameObject _lifeTemplate;
    [SerializeField] private Image _healthMask, _manaMask;
    
    private float _healthOriginalSize, _manaOriginalSize;

    public HealthBar instance { get; private set; }


    void Awake() {
        instance = this;
    }

    void Update() {
        int lifeShowNumber = GameObject.FindGameObjectsWithTag("Life").Length;

        if (lifeShowNumber != PlayerController.life) {
            foreach (GameObject life in GameObject.FindGameObjectsWithTag("Life")) {
                Destroy(life);
            }
            
            ShowCurrentLife();   
        }
    }


    void Start() {
        ShowCurrentLife();
        _healthOriginalSize = _healthMask.rectTransform.rect.width;
        
        if (_manaMask != null) 
            _manaOriginalSize = _manaMask.rectTransform.rect.width;
    }

    void ShowCurrentLife() {
        GameObject parent = GameObject.Find("LifeUI");

        for (int i = 0; i < PlayerController.life; i++) {

                RectTransform lifeImageRectTransform = Instantiate(_lifeTemplate, GetComponent<RectTransform>()).GetComponent<RectTransform>();

                
                lifeImageRectTransform.SetParent(parent.transform);
                lifeImageRectTransform.gameObject.SetActive(true);

                lifeImageRectTransform.anchoredPosition = new Vector2(lifeImageRectTransform.rect.width / 2 +  i*(lifeImageRectTransform.rect.width + 1f) , -parent.GetComponent<RectTransform>().rect.height / 2);
            }
    }

    public void Show(bool value) {
        gameObject.GetComponent<Image>().enabled = value;
        _healthMask.enabled = value;

        if (_manaMask != null) 
            _manaMask.enabled = value;
    }


    public void SetHealthValue(float value) {
        _healthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _healthOriginalSize * value);
    }


    public void SetManaValue(float value) {
        _manaMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _manaOriginalSize * value);
    }
}