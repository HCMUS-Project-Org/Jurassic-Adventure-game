using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _levelCompleteUI, _levelFailedUI, _pauseMenuUI;
    [SerializeField] private int _level;
    
    public static bool isGamePaused = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape key pressed");
            if (isGamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }


    // Update is called once per frame
    public void RestartGame() {
        Debug.Log("Restart level");
    }


    public void PauseGame() {
        Debug.Log("Pause game");
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }


    public void ResumeGame() {
        Debug.Log("Resume game");
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }


    public void QuitGame() {
        Debug.Log("Quit level");
    }
}
