using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour {
    private float _timerDisplay;

    public float displayTime = 4.0f;
    public GameObject dialogBox;


    void Start() {
        dialogBox.SetActive(false);
        
        _timerDisplay = -1.0f;
    }


    void Update() {
        if (_timerDisplay >= 0) {
            _timerDisplay -= Time.deltaTime;
            
            if (_timerDisplay < 0) {
                dialogBox.SetActive(false);
            }
        }
    }


    public void DisplayDialog() {
        _timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
