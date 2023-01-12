using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class NextCutScene : MonoBehaviour, IPointerDownHandler {

    [SerializeField] TMPro.TextMeshProUGUI _sceneText;
    [SerializeField] GameObject _currentCutScene;
    [SerializeField] GameObject _nextCutScene;

    private int _clickTime = 0;
    
    private string _fullText;


    void Awake() {
        _sceneText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        _fullText = _sceneText.GetComponent<TypeWriterEffect>().fullText;
            
    }

    private void NextScene() {
        // load next cutscene
        if (_nextCutScene) {
            _currentCutScene.SetActive(false);
            _nextCutScene.SetActive(true);    
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        _clickTime++;
        
        if (_clickTime == 1) {
            // stop TypeWriterEffect script
            _sceneText.GetComponent<TypeWriterEffect>().StopTypeWriterCorountine();

            if (_fullText.Equals(_sceneText.text))
            {
                NextScene();
            }
            else
            {
                _sceneText.text = _fullText;

                // stop sound
                GameObject.Find("Voice").GetComponent<AudioSource>().enabled = false;
            }

        }
        else {
            NextScene();
        }
    }
}
