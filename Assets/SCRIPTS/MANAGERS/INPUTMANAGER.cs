using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUTMANAGER : MonoBehaviour
{
    private PLAYER player;

    private PauseButtons pauseButtons;

    private GAMEMANAGER gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!gameManager.isPauuuse)
        {
            float axisH = Input.GetAxis("Horizontal");
            player.SetAxis(axisH);

            if (Input.GetButtonDown("Jump"))
            {
                player.StartJump();
            }

            if (Input.GetKey(KeyCode.F10))
            {
                player.GodJump();
            }

            if (Input.GetKey(KeyCode.F9))
            {
                player.controller.enabled = true;
                player.panel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.isPauuuse = true;

            if (gameManager.gamePaused) gameManager.Resume();
            else gameManager.Pause();
        }

        if (gameManager.gamePaused) return;

    }
}
