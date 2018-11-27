using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour
{
    public bool gameover;
    public int countdown;

    public bool gamePaused;

    private HUD hud;

    public bool isPauuuse;

    private void Awake()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        countdown = 0;

        hud.UpdateCountdown(countdown);

    }

    public void Resume()
    {
        isPauuuse = false;
        gamePaused = false;
        Time.timeScale = 1;
        hud.ClosePausePanel();
    }

    public void Pause()
    {
        isPauuuse = true;
        gamePaused = true;
        Time.timeScale = 0;
        hud.OpenPausePanel();
    }

    public void LoadScene(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }

    public void Addcountdown(int newTime)
    {
        countdown += newTime;
        hud.UpdateCountdown(countdown);
    }

    private void SaveGame()
    {
        int highScore = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }

        if (countdown > highScore)
        {
            highScore = countdown;
        }

        PlayerPrefs.SetInt("TIME", countdown);
        PlayerPrefs.SetInt("BEST TIME", highScore);
    }

    public void GameOver()
    {
        gameover = true;
        SaveGame();

        LoadScene(3);
    }

    public void PlayerLife(int pLife)
    {
        hud.UpdatePlayerLife(pLife);
    }
}
