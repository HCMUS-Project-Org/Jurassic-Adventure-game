using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _levelCompleteUI, _levelFailedUI, _pauseMenuUI, _shopUI, _confirmExitUI;
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private Sprite _pauseBtnImg, _resumeBtnImg;
    [SerializeField] private int _level;
    
    public static bool isGamePaused = false;
    public static bool isOpenShop = false;
    public static bool isConfirmExit = false;


    void Update() {

        // Exit game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused || isConfirmExit) 
                ResumeGame();
            else 
                ConfirmExitGame();
        }

        // Pause game
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isOpenShop || isConfirmExit)
                PauseGame();
            else if (isGamePaused) 
                ResumeGame();
            else
                PauseGame();
        }

        // Open Shop
        if (Input.GetKeyDown(KeyCode.O)) {
            if (isOpenShop) 
                ResumeGame();
            else 
                OpenShop();
        }
    }


    public void ConfirmExitGame() {
        ResumeGame();
        PauseGame();

        if (_pauseMenuUI != null) 
            _pauseMenuUI.SetActive(false);
        
        _confirmExitUI.SetActive(true);
        
        isConfirmExit = true;
    }

    public void OpenShop() {
        ResumeGame();
        PauseGame();

        if (_pauseMenuUI != null) 
            _pauseMenuUI.SetActive(false);

        _shopUI.SetActive(true);

        isOpenShop = true;
    }


    public void RestartGame() {
        Debug.Log("Restart level");
    }


    public void PauseGame() {
        Debug.Log("Pause game");
        ResumeGame();

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _resumeBtnImg;

        _pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        
        isGamePaused = true;
    }


    public void ResumeGame() {
        Debug.Log("Resume game");

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _pauseBtnImg;

        _pauseMenuUI.SetActive(false);
        _shopUI.SetActive(false);
        _confirmExitUI.SetActive(false);
        
        Time.timeScale = 1f;
        
        isGamePaused = false;
        isOpenShop = false;
        isConfirmExit = false;
    }


    public void QuitGame() {
        Debug.Log("Quit level");
    }
}
