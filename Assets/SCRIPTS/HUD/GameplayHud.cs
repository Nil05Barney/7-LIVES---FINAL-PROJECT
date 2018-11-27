using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHud : MonoBehaviour
{
    public float time = 0.0f;

    public Text countdown;
    public Text lifeText;

    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

        UpdateCountdown(57);
        UpdateLifeText(5);
    }

    public void UpdateLifeText(int newLife)
    {
        lifeText.text = "x " + newLife.ToString(" 0");
    }

    public void UpdateCountdown(int newTime)
    {
        time -= Time.deltaTime;
        countdown.text = "" + time.ToString("0.0");

        if (time <= 5)
        {
            anim.SetBool("5left", true);
        }

        if (time <= 0)
        {
            Debug.Log("DEATH");
            anim.SetBool("5left", false);
            Time.timeScale = 0;
        }
    } 
}
