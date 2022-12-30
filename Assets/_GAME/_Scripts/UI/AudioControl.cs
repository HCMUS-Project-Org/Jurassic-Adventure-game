using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{

    public static AudioControl instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;
    private decimal _vol, _bgm, _sfx;

    [SerializeField] private Image _volBar,_bgmBar,_sfxBar;
    public Sprite _zero, _twenty, _fourty, _sixty, _eighty, _hunderd;

    [SerializeField] private GameObject _soundSettingButton, _bgmSettingButton, _sfxSettingButton;
    [SerializeField] private Sprite _soundOnSpriteDefault, _soundOnSpritePressed;
    [SerializeField] private Sprite _soundOffSpriteDefault, _soundOffSpritePressed;

    private bool _isMute = false, _isBGMMute = false, _isSFXMute = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        _vol = (decimal) PlayerPrefs.GetFloat("VOL", 1f);
        _bgm = (decimal) PlayerPrefs.GetFloat("BGM", 1f);
        _sfx = (decimal) PlayerPrefs.GetFloat("SFX", 1f);

        AudioListener.volume = (float)_vol;
        _musicSource.volume = (float)_bgm;
        _effectSource.volume = (float)_sfx;


        UpdateBar(_volBar, (float)_vol);
        UpdateBar(_bgmBar, (float)_bgm);
        UpdateBar(_sfxBar, (float)_sfx);

    }

    public void IncreaseVolume(int type)
    {
        switch (type)
        {
            case 1:
                {
                    if (_vol >= 1)
                        _vol = 1;
                    else
                        _vol += 0.2m;

                    AudioListener.volume = (float)_vol;
                    UpdateBar(_volBar, (float)_vol);
                    PlayerPrefs.SetFloat("VOL", (float) _vol);
                } 
            break;

            case 2:
                {
                    if (_bgm >= 1)
                        _bgm = 1;
                    else
                        _bgm += 0.2m;

                    _musicSource.volume = (float)_bgm;
                    UpdateBar(_bgmBar, (float)_bgm);
                    PlayerPrefs.SetFloat("BGM", (float)_bgm);

                }
                break;

            case 3:
                {
                    if (_sfx >= 1)
                        _sfx = 1;
                    else
                        _sfx += 0.2m;

                    _effectSource.volume = (float)_sfx;
                    UpdateBar(_sfxBar, (float)_sfx);
                    PlayerPrefs.SetFloat("SFX", (float)_sfx);

                }
                break;
        }

    }

    public void DecreaseVolume(int type)
    {
        switch (type)
        {
            case 1:
                {
                    if (_vol <= 0)
                        _vol = 0;   
                    else
                        _vol -= 0.2m;

                    AudioListener.volume = (float)_vol;
                    UpdateBar(_volBar, (float)_vol);
                    PlayerPrefs.SetFloat("VOL", (float)_vol);

                }
                break;

            case 2:
                {
                    if (_bgm <= 0)
                        _bgm = 0;
                    else
                        _bgm -= 0.2m;

                    _musicSource.volume = (float)_bgm;
                    UpdateBar(_bgmBar, (float)_bgm);
                    PlayerPrefs.SetFloat("BGM", (float)_bgm);

                }
                break;

            case 3:
                {
                    if (_sfx <= 0)
                        _sfx = 0;
                    else
                        _sfx -= 0.2m;

                    _effectSource.volume = (float)_sfx;
                    UpdateBar(_sfxBar, (float)_sfx);
                    PlayerPrefs.SetFloat("SFX", (float)_sfx);
                }
                break;
        }
    }


    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip Music)
    {
        if (instance != null)
        {
            Debug.Log("Instace");
            if (instance._musicSource != null)
            {
                Debug.Log("Success");
                instance._musicSource.Stop();
                instance._musicSource.clip = Music;
                instance._musicSource.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }



    public void UpdateBar(Image _img,float value)
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

    public void ToggleVolume()
    {
        if (_isMute)
        {
            _soundSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _soundSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;

            AudioListener.volume = (float) _vol;
        }
        else
        {
            _soundSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _soundSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;

            AudioListener.volume = 0;
        }

        _isMute = !_isMute;

    }

    public void ToggleMusic()
    {
        if (_isBGMMute)
        {
            _bgmSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _bgmSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;
        }
        else
        {
            _bgmSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _bgmSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;
        }

        _musicSource.mute = !_musicSource.mute;
        _isBGMMute = !_isBGMMute;

    }

    public void ToggleEffects()
    {
        if (_isSFXMute)
        {
            Debug.Log("Sound on");

            _sfxSettingButton.GetComponent<ClickyButton>()._default = _soundOffSpriteDefault;
            _sfxSettingButton.GetComponent<ClickyButton>()._pressed = _soundOffSpritePressed;
        }
        else
        {
            Debug.Log("Sound off");

            _sfxSettingButton.GetComponent<ClickyButton>()._default = _soundOnSpriteDefault;
            _sfxSettingButton.GetComponent<ClickyButton>()._pressed = _soundOnSpritePressed;

        }

        _effectSource.mute = !_effectSource.mute;
        _isSFXMute = !_isSFXMute;
        
    }


}