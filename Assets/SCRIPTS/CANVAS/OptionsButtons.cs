using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtons : MonoBehaviour
{
    public GameObject optionsPanel;
    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    public void Resolution(int num)
    {
        Debug.Log("RESOLUTION" + num); 
        anim.SetBool("Resolution", true);
        anim.SetBool("Quality", false);
        anim.SetBool("Controls", false);
    }

    public void Resolution1280x720(int num)
    {
        Screen.SetResolution(1280, 720, true);
        Debug.Log("1280 x 720");
    }

    public void Resolution1600x1200​(int num)
    {
        Screen.SetResolution(1600, 1200, true);
        Debug.Log("1600 x 1200​");
    }

    public void Resolution​1920x1080(int num)
    {
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("1920 x 1080​");
    }

//------------------------------------------------------------------------------------

    public void Quality(int num)
    {
        Debug.Log("QUALITY" + num);

        anim.SetBool("Quality", true);
        anim.SetBool("Resolution", false);
        anim.SetBool("Controls", false);

    }

    public void QualityLow(int num)
    {
        Debug.Log("LOW");
        QualitySettings.SetQualityLevel(1);
    }

    public void QualityMedium(int num)
    {
        Debug.Log("MEDIUM");
        QualitySettings.SetQualityLevel(2);
    }

    public void QualityHigh(int num)
    {
        Debug.Log("HIGH");
        QualitySettings.SetQualityLevel(3);
    }

    public void QualityUltra(int num)
    {
        Debug.Log("ULTRA");
        QualitySettings.SetQualityLevel(5);
    }

//------------------------------------------------------------------------------------

    public void Color(int num)
    {
        Debug.Log("COLOR" + num);
    }

    public void Audio(int num)
    {
        Debug.Log("AUDIO");
    }

//-----------------------------------------------------------------------------------

    public void Controls(int num)
    {
        Debug.Log("CONTROLS");
        anim.SetBool("Quality", false);
        anim.SetBool("Resolution", false);
        anim.SetBool("Controls", true);

    }

    //-----------------------------------------------------------------------------------

    public void Return()
    {
        Debug.Log("RETURN");
        SceneManager.LoadScene(1);
    }

    public void ReturnInGame()
    {
        Debug.Log("RETURN IN GAMEEEE????????");

    }
}
