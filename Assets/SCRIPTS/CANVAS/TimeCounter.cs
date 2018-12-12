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

    private GAMEMANAGER gameManager;

    private PLAYER_VIDA player;

    //public GameObject panel;

    public int attackDamage = 1;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER_VIDA>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        countdown.text = "" + time.ToString("0.0");

        if (time >= 5)
        {
            anim.SetBool("5left", false);
        }

        if (time <= 5)
        {
            anim.SetBool("5left", true);
        }

        if (time <= 0)
        {
            time = 30;

            anim.SetBool("5left", false);

            player.TakeDamage(attackDamage);
        }

        if (time <= -5)
        {
            SceneManager.LoadScene(5);
        }
    }

    public void ResetTiempo()
    {
        time = 30;
    }

    public void SumarTiempo()
    {
        time += 15;
    }
}