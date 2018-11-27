using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour 
{
    public GameObject menuPanel;

    public Animator anim;

    // Use this for initialization

    public void Start()
    {
        if (Input.GetButtonDown("Enter"))
        {
            anim.SetTrigger("CLICKSTART");
        }
    }

    public void ClickStart(int num)
    {
        Debug.Log("STAAAAAAART GAME" + num);
        anim.SetTrigger("CLICKSTART");
    }

    public void PlayGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        SceneManager.LoadScene(2);
    }

	public void OptionsGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        SceneManager.LoadScene(4);
    }

	public void CreditsGame(int num)
    {
        Debug.Log("ControlsGame" + num);
        SceneManager.LoadScene(6);
    }
	
	public void ExitGame(int num)
    {
        Debug.Log("EXIT GAME");
        Application.Quit();
    }
}
