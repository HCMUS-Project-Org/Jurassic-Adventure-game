using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject[]     _enemies;
    [SerializeField] private GameObject       _player;
    [SerializeField] private GameObject       _levelCompleteUI, _levelFailedUI;
    [SerializeField] private GameObject       _pauseMenuUI, _shopUI, _inventoryUI, _mapUI, _confirmExitUI, _dieCountDowndUI, _settingUI;
    [SerializeField] private GameObject       _pauseBtn;
    [SerializeField] private GameObject       _zoomCameraController;
    [SerializeField] private Sprite           _pauseBtnImg, _resumeBtnImg;
    [SerializeField] private UIInventory      _inventoryMenu;
    [SerializeField] private TMPro.TextMeshProUGUI _countDownText;
    private                  InventoryManager _inventoryManager;
    private                  EquipmentManager _equipmentManager;

    [SerializeField] private GameObject _libraryPanel;

    [SerializeField] private int _level;

    private bool _isGamePaused    = false;
    private bool _isOpenShop      = false;
    private bool _isOpenSetting = false;
    private bool _isOpenInventory = false;
    private bool _isOpenMap = false;
    private bool _isConfirmExit   = false;
    private bool _timerIsRunning = false;

    private bool _isOpenLibrary = false;

    private float _timeRemaining;

    public static bool _isPlayerRevival = false;
    public static int currentLevel = 1;

    void Start() {
        _inventoryManager = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;
        _equipmentManager = FindObjectOfType(typeof(EquipmentManager)) as EquipmentManager;

        _timeRemaining = 4;
    }

    void Update() {
        // time count down
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                RespawnPlayer();
            }
        }

        // Exit game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_isGamePaused || _isConfirmExit)
                ResumeGame();
            else
                ConfirmExitGame();
        }

        // Pause game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_isOpenShop || _isConfirmExit || _isOpenInventory || _isOpenMap)
                PauseGame();
            else if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }

        // Open Shop
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (_isOpenShop)
                ResumeGame();
            else
                OpenShop();
        }

        // Open Inventory
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (_isOpenInventory)
                ResumeGame();
            else
                OpenInventory();
        }

        // Open Map
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_isOpenMap)
                ResumeGame();
            else
                OpenMap();
        }
        
        // Open Library
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_isOpenLibrary)
                ResumeGame();
            else
                OpenLibrary();
        }
    }

    private void OpenLibrary()
    {
        _libraryPanel.SetActive(true);
        _isOpenLibrary = true;
    }

    public void PassLevel() {
        ShowLevelCompleteUI();
    }

    public void ShowLevelCompleteUI() {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _levelCompleteUI.SetActive(true);
    }

    public void ShowLevelFailedUI() {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _levelFailedUI.SetActive(true);
    }


    public void ShowDieCountDown() {
        _dieCountDowndUI.SetActive(true);
        _timerIsRunning = true;
    }

    void HideDieCountDown() {
        _dieCountDowndUI.SetActive(false);
        _timerIsRunning = false;

        // time Revival  4 - 6 - 9 -> (Show: 3 - 5 - 8)
        _timeRemaining = (PlayerController.maxLife - PlayerController.currentLife + 1) * PlayerController.maxLife;    
    }

    void RespawnPlayer() {
        HideDieCountDown();
        
        // reset player health
        PlayerHealth playerHealth = _player.GetComponent<PlayerHealth>();
        playerHealth.ChangeHealth(9999);
        playerHealth.ChangeMana(9999);

        // enable player movement
        PlayerMovement playerMovement = _player.GetComponent<PlayerMovement>();
        playerMovement.enabled = true;

        // enable player simulated
        Rigidbody2D playerRigidbody2d = _player.GetComponent<Rigidbody2D>();
        playerRigidbody2d.simulated = true;

        // enable player animator
        Animator _playerAnimator = _player.GetComponent<Animator>();
        _playerAnimator.SetTrigger("Revival");
        _isPlayerRevival = true;

        
    }


    void DisplayTime(float timeToDisplay) {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _countDownText.text = seconds.ToString();
    }



    public void ConfirmExitGame()
    {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _confirmExitUI.SetActive(true);

        _isConfirmExit = true;
    }


    public void OpenShop()
    {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _shopUI.SetActive(true);

        _isOpenShop = true;
    }

    public void OpenSetting()
    {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _settingUI.SetActive(true);

        _isOpenSetting = true;
    }

    public void OpenMap()
    {
        ResumeGame();

        _player.SetActive(false);
        _pauseMenuUI.SetActive(false);
        _mapUI.SetActive(true);
        _zoomCameraController.SetActive(true);

        _isOpenMap = true;
        _isGamePaused = true;
    }


    public void OpenInventory()
    {
        ResumeGame();
        PauseGame();

        _pauseMenuUI.SetActive(false);
        _inventoryUI.SetActive(true);

        // refesh inventory
        _inventoryMenu.SetInventory(_inventoryManager);

        _isOpenInventory = true;
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        Debug.Log("Restart level");
    }


    public void PauseGame()
    {
        Debug.Log("Pause game");
        ResumeGame();

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _resumeBtnImg;

        _player.SetActive(false);

        _pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;

        _isGamePaused = true;
    }


    public void ResumeGame()
    {
        Debug.Log("Resume game");

        // change pause btn sprite
        _pauseBtn.GetComponent<Image>().sprite = _pauseBtnImg;

        _pauseMenuUI.SetActive(false);
        _shopUI.SetActive(false);
        _inventoryUI.SetActive(false);
        _mapUI.SetActive(false);
        _confirmExitUI.SetActive(false);
        _zoomCameraController.SetActive(false);
        _libraryPanel.SetActive(true);

        _player.SetActive(true);

        Time.timeScale = 1f;

        _isGamePaused    = false;
        _isOpenShop      = false;
        _isOpenInventory = false;
        _isOpenMap       = false;
        _isConfirmExit   = false;
        _isOpenLibrary   = false;
    }


    public void QuitGame()
    {
        Debug.Log("Quit level");
    }
}