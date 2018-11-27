using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LOGO_TIME : MonoBehaviour {

    public Text timeText;
    public float time = 0.0f;

    public Animator anim;

    public void Update()
    {
        if (time <= 0)
        {
            SceneManager.LoadScene(1);
        }


        time -= Time.deltaTime;

        timeText.text = "" + time.ToString("0");

    }

    public void TitelTime(int num)
    {

        if (time == 0)
        {
            SceneManager.LoadScene(1);
        }

    }
}

