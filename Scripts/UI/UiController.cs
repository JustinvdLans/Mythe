using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static bool gamePaused = false;

    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject cannonsRight;
    [SerializeField] GameObject cannonsLeft;
    [SerializeField] Camera playerCamera;


    public void SettingsMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Settings");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
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
        playerCamera.GetComponent<CameraScript>().enabled = true;
        cannonsLeft.SetActive(true);
        cannonsRight.SetActive(true);
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void PauseGame()
    {
        playerCamera.GetComponent<CameraScript>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
