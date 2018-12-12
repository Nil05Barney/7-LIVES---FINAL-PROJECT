using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour 
{
    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;

    public Animator anim;

    public void Update()
    {
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true); 
    }

    public void ClickStart(int num)
    {
        Debug.Log("STAAAAAAART GAME" + num);
        //SceneManager.LoadScene(2);
    }

    public void PlayGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        SceneManager.LoadScene(2);
    }

	public void OptionsGame(int num)
    {
        Debug.Log("ControlsGame" + num);

        menuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

	public void CreditsGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        menuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
	
	public void ExitGame(int num)
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}
