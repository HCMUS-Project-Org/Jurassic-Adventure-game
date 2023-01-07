using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMainMenu : MonoBehaviour
{
    public void ConfirmPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}