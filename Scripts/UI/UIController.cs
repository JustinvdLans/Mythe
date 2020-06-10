using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics.Tracing;

public class UIController : MonoBehaviour
{
    public static bool gamePaused = false;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cannonsRight;
    [SerializeField] GameObject cannonsLeft;


    public void SettingsMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Movement");
    }

    public void QuitToDesktop()
    {
        Debug.Log("I Quit the game");
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        player.GetComponentInChildren<ThirdPerson>().enabled = true;
        player.GetComponentInChildren<CameraController>().enabled = false;
        cannonsLeft.SetActive(true);
        cannonsRight.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        player.GetComponentInChildren<ThirdPerson>().enabled = false;
        player.GetComponentInChildren<CameraController>().enabled = false;
        cannonsRight.SetActive(false);
        cannonsLeft.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

}
