using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float time = 0.0f;
    public Text countdown;
    public Animator anim;

    public int extraTime;

    private GAMEMANAGER gameManager;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();
        // Update life UI
        gameManager.Addcountdown(extraTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            Debug.Log("DEATH");
            anim.SetBool("5left", false);
            Time.timeScale = 0;
        }

        time -= Time.deltaTime;

        countdown.text = "" + time.ToString("0.0");

        if (time <= 5)
        {
            anim.SetBool("5left", true);
        }

    }

    public void ExtraTime(int amount)
    {
        extraTime += amount;
        gameManager.Addcountdown(extraTime);
    }
}