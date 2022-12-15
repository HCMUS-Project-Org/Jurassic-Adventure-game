using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundController : MonoBehaviour {

    [SerializeField] private GameObject _soundSettingButton;
    [SerializeField] private Sprite _soundOnSpriteDefault, _soundOnSpritePressed;
    [SerializeField] private Sprite _soundOffSpriteDefault, _soundOffSpritePressed;
    private float _soundVolume;
    private bool _isMute = false;

    void Start() {
        _soundVolume = AudioListener.volume;
    }


    public void ChangeSound() {
        if (_isMute) {
            Debug.Log("Sound on");

            _soundSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _soundSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;

            AudioListener.volume = _soundVolume;
        }
        else {
            Debug.Log("Sound off");

            _soundSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _soundSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;
            
            AudioListener.volume = 0;
        }

        _isMute = !_isMute;
    }
}
