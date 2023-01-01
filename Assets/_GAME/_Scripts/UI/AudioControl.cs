using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{

    public static AudioControl instance;

    [SerializeField] private AudioSource _musicSource, _effectSource;
    private decimal _vol, _bgm, _sfx;

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


    }

    public float GetVol()
    {
        return (float) _vol;
    }
    public float GetBGM()
    {
        return (float)_bgm;
    }
    public float GetSFX()
    {
        return (float)_sfx;
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
            if (instance._musicSource != null)
            {
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

    public void ToggleVolume(bool isMute)
    {
        if(!isMute)
            AudioListener.volume = 0;
        else
            AudioListener.volume = (float) _vol;

    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }

    public void ToggleEffects()
    { 
        _effectSource.mute = !_effectSource.mute;   
    }


}