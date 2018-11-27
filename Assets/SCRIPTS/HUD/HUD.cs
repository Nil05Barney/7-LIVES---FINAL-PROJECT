using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject pausePanel;

    public Text countdown;
    public Text lifeText;

    // Use this for initialization
    void Start()
    {
        ClosePausePanel();
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void UpdateCountdown(int time)
    {

        countdown.text = time.ToString("00.00");

    }

    public void UpdatePlayerLife(int pLife)
    {
        lifeText.text = "x" + pLife.ToString();
    }
}
