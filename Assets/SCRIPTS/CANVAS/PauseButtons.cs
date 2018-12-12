using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionsPanel;
    private GAMEMANAGER gameManager;

    public bool gamePaused;

    // Use this for initialization
    void Start()
    {
        gamePaused = false;
        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();
    }

    void Update()
    {
        optionsPanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);

        gamePaused = true;

        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        gamePaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1;

        gameManager.Resume();
    }

    public void Restart(int num)
    {
        Debug.Log("REEEEEESTAAAAART" + num);
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void OptionsPause(int num)
    {
        Debug.Log("OPTIONS---PAUSE" + num);
        optionsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void Home(int num)
    {
        Time.timeScale = 1;
        Debug.Log("HOOOOMEEEEE" + num);
        SceneManager.LoadScene(1);
    }

}
