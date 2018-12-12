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

    //private PLAYER player;

    private PHYSICS_PLAYER physics;

    private void Awake()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER>();
        physics = GameObject.FindGameObjectWithTag("Player").GetComponent<PHYSICS_PLAYER>();

        countdown = 0;

        hud.UpdateCountdown(countdown);

        physics.Initialation();
        //player.Init();
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
        hud.OpenPausePanel();
        isPauuuse = true;
        gamePaused = true;
        Time.timeScale = 0;
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

        if (PlayerPrefs.HasKey("BEST TIME"))
        {
            highScore = PlayerPrefs.GetInt("BEST TIME");
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
    }

    public void PlayerLife(int pLife)
    {
        hud.UpdatePlayerLife(pLife);
    }
}
