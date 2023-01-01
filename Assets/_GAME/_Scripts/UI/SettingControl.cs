using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    [SerializeField] private Image _volBar, _bgmBar, _sfxBar;
    public Sprite _zero, _twenty, _fourty, _sixty, _eighty, _hunderd;

    [SerializeField] private GameObject _volumnSettingButton, _musicSettingButton, _effectSettingButton;
    [SerializeField] private Sprite _soundOnSpriteDefault, _soundOnSpritePressed;
    [SerializeField] private Sprite _soundOffSpriteDefault, _soundOffSpritePressed;

    private bool _isMute = false, _isBGMMute = false, _isSFXMute = false;


    private void Start()
    {
        UpdateBar(_volBar, AudioControl.instance.GetVol());
        UpdateBar(_bgmBar, AudioControl.instance.GetBGM());
        UpdateBar(_sfxBar, AudioControl.instance.GetSFX());
    }
    public void UpdateBar(Image _img, float value)
    {

        switch (value)
        {
            case 0f: _img.sprite = _zero; break;
            case 0.2f: _img.sprite = _twenty; break;
            case 0.4f: _img.sprite = _fourty; break;
            case 0.6f: _img.sprite = _sixty; break;
            case 0.8f: _img.sprite = _eighty; break;
            case 1f: _img.sprite = _hunderd; break;
        }
    }

    public void IncreaseVolume(int type)
    {
        AudioControl.instance.IncreaseVolume(type);

        switch (type)
        {
            case 1:
                {
                    UpdateBar(_volBar, AudioControl.instance.GetVol());


                    if (AudioControl.instance.GetVol() != 0)
                    {
                        _volumnSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isMute = !_isMute;
                    }
                }
                break;

            case 2:
                {
                    UpdateBar(_bgmBar, AudioControl.instance.GetBGM());

                    if (AudioControl.instance.GetBGM()  != 0)
                    {
                        _musicSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isBGMMute = !_isBGMMute;
                        AudioControl.instance.ToggleMusic();

                    }
                }
                break;

            case 3:
                {
                    UpdateBar(_sfxBar, AudioControl.instance.GetSFX());

                    if (AudioControl.instance.GetSFX() != 0)
                    {
                        _musicSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isSFXMute = !_isBGMMute;
                        AudioControl.instance.ToggleEffects();
                    }
                }
                break;
        }

    }

    public void DecreaseVolume(int type)
    {
        AudioControl.instance.DecreaseVolume(type);

        switch (type)
        {
            case 1:
                {
                    UpdateBar(_volBar, AudioControl.instance.GetVol());

                    if (AudioControl.instance.GetVol() == 0)
                        _volumnSettingButton.GetComponent<Image>().sprite = _soundOffSpriteDefault;
                    else
                    {
                        _volumnSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isMute = !_isMute;
                    }
                }
                break;

            case 2:
                {
                    UpdateBar(_bgmBar, AudioControl.instance.GetBGM());
                    

                    if (AudioControl.instance.GetBGM() == 0)
                        _musicSettingButton.GetComponent<Image>().sprite = _soundOffSpriteDefault;
                    else
                    {
                        _musicSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isBGMMute = !_isBGMMute;
                        AudioControl.instance.ToggleMusic();
                    }
                }
                break;

            case 3:
                {
                    UpdateBar(_sfxBar, AudioControl.instance.GetSFX());

                    if (AudioControl.instance.GetSFX() == 0)
                        _effectSettingButton.GetComponent<Image>().sprite = _soundOffSpriteDefault;
                    else
                    {
                        _musicSettingButton.GetComponent<Image>().sprite = _soundOnSpriteDefault;
                        _isSFXMute = !_isBGMMute;
                        AudioControl.instance.ToggleEffects();
                    }
                }
                break;
        }
    }


    public void ToggleVolume()
    {
        if (_isMute)
        {
            _volumnSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _volumnSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;
            AudioControl.instance.ToggleVolume(_isMute);

        }
        else
        {
            _volumnSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _volumnSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;
            AudioControl.instance.ToggleVolume(_isMute);

        }

        _isMute = !_isMute;

    }

    public void ToggleMusic()
    {
        if (_isBGMMute)
        {
            _musicSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _musicSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;

        }
        else
        {
            _musicSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _musicSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;

        }

        AudioControl.instance.ToggleMusic();
        _isBGMMute = !_isBGMMute;

    }

    public void ToggleEffects()
    {
        if (_isSFXMute)
        {
            _effectSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _effectSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;
        }
        else
        {
            _effectSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _effectSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;
        }

        AudioControl.instance.ToggleEffects();
        _isSFXMute = !_isSFXMute;

    }
}
