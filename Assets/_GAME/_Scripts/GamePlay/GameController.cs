using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _levelCompleteUI, _levelFailedUI;
    [SerializeField] private GameObject _pauseMenuUI, _shopUI, _inventoryUI, _confirmExitUI;
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private Sprite _pauseBtnImg, _resumeBtnImg;
    [SerializeField] private UIInventory _inventoryMenu;
    private                  InventoryManager _inventoryManager;
    
    [SerializeField] private int _level;

    private bool _isGamePaused = false;
    private bool _isOpenShop = false;
    private bool _isOpenInventory = false;
    private bool _isConfirmExit = false;

    void Start() {
        _inventoryManager = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;
    }

    void Update() {
        // Exit game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_isGamePaused || _isConfirmExit) 
                ResumeGame();
            else 
                ConfirmExitGame();
        }

        // Pause game
        if (Input.GetKeyDown(KeyCode.P)) {
            if (_isOpenShop || _isConfirmExit || _isOpenInventory)
                PauseGame();
            else if (_isGamePaused) 
                ResumeGame();
            else
                PauseGame();
        }

        // Open Shop
        if (Input.GetKeyDown(KeyCode.O)) {
            if (_isOpenShop) 
                ResumeGame();
            else 
                OpenShop();
        }

        // Open Inventory
        if (Input.GetKeyDown(KeyCode.B)) {
            if (_isOpenInventory) 
                ResumeGame();
            else 
                OpenInventory();
        }
    }


    public void ConfirmExitGame() {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _confirmExitUI.SetActive(true);
        
        _isConfirmExit = true;
    }


    public void OpenShop() {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _shopUI.SetActive(true);

        _isOpenShop = true;
    }


    public void OpenInventory() {
        ResumeGame();
        PauseGame();
        
        // refesh inventory

        _pauseMenuUI.SetActive(false);
        _inventoryUI.SetActive(true);
        
        _inventoryMenu.SetInventory(_inventoryManager);

        _isOpenInventory = true;
    }


    public void RestartGame() {
        Debug.Log("Restart level");
    }


    public void PauseGame() {
        Debug.Log("Pause game");
        ResumeGame();

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _resumeBtnImg;

        _player.SetActive(false);
        
        _pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        
        _isGamePaused = true;
    }


    public void ResumeGame() {
        Debug.Log("Resume game");

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _pauseBtnImg;

        _pauseMenuUI.SetActive(false);
        _shopUI.SetActive(false);
        _inventoryUI.SetActive(false);
        _confirmExitUI.SetActive(false);
        
        _player.SetActive(true);

        Time.timeScale = 1f;
        
        _isGamePaused = false;
        _isOpenShop = false;
        _isOpenInventory = false;
        _isConfirmExit = false;
    }


    public void QuitGame() {
        Debug.Log("Quit level");
    }
}
