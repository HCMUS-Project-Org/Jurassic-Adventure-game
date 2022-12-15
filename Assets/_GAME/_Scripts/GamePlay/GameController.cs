using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _levelCompleteUI, _levelFailedUI, _pauseMenuUI, _shopUI;
    
    [SerializeField] private int _level;
    
    public static bool isGamePaused = false;
    public static bool isOpenShop = false;


    void Update() {
        // Pause game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }

        // Open Shop
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isOpenShop) {
                ResumeGame();
            }
            else {
                OpenShop();
            }
        }
    }


    void OpenShop() {
        Time.timeScale = 0f;

        if (_pauseMenuUI != null) 
            _pauseMenuUI.SetActive(false);

        _shopUI.SetActive(true);
        
        isGamePaused = true;
        isOpenShop = true;
    }


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

        if (_pauseMenuUI != null) 
            _pauseMenuUI.SetActive(false);

        _shopUI.SetActive(false);
        
        Time.timeScale = 1f;
        
        isGamePaused = false;
        isOpenShop = false;
    }


    public void QuitGame() {
        Debug.Log("Quit level");
    }
}
