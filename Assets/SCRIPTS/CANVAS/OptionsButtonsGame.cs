using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtonsGame : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject pausePanel;
    public GameObject resolutionImage;
    public GameObject qualityImage;
    public GameObject controlsImage;

    public void Awake()
    {
        resolutionImage.SetActive(false);
        qualityImage.SetActive(false);
        controlsImage.SetActive(false);
    }

    public void Resolution(int num)
    {
        Debug.Log("RESOLUTION" + num);
        resolutionImage.SetActive(true);
        qualityImage.SetActive(false);
        controlsImage.SetActive(false);
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
        resolutionImage.SetActive(false);
        qualityImage.SetActive(true);
        controlsImage.SetActive(false);
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
        resolutionImage.SetActive(false);
        qualityImage.SetActive(false);
        controlsImage.SetActive(true);
    }

    //-----------------------------------------------------------------------------------

    public void Return()
    {
        Debug.Log("RETURN");
        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);
        resolutionImage.SetActive(false);
        qualityImage.SetActive(false);
        controlsImage.SetActive(false);
    }
}
