using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public GameObject pausePanel;

    public bool gamePaused;

    // Use this for initialization
    void Start()
    {
        pausePanel.SetActive(false);
        gamePaused = false;

    }

    public void Pause()
    {
        gamePaused = true;

        pausePanel.SetActive(true);

        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        gamePaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void Restart(int num)
    {
        Debug.Log("REEEEEESTAAAAART" + num);
        SceneManager.LoadScene(2);
    }

    public void OptionsPause(int num)
    {
        Debug.Log("OPTIONS---PAUSE" + num);
        SceneManager.LoadScene(5);
    }

    public void Home(int num)
    {
        Debug.Log("HOOOOMEEEEE" + num);
        SceneManager.LoadScene(1);
    }

    /*public void ControlsGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        SceneManager.LoadScene(12);
    }

    public void Menu(int num)
    {
        Debug.Log("menu" + num);
        SceneManager.LoadScene(1);

    }*/


}
