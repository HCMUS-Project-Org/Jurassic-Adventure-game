using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    [SerializeField] private AudioClip Music;

    private void Start()
    {
        LoadMusic();
    }

    public void LoadMusic()
    {
        AudioControl.instance.PlayMusic(Music);
    }
}
