using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PLAYER_VIDA : PLAYER
{
    public int startingHealth = 5;
    public int currentHealth;

    public Image damageImage;
    //public Image lifeImage;

    //public AudioSource Pain;

    public float flashSpeed = 5f;
    public float flashSpeedLife = 15f;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    //public Color flashColourLife = new Color(0f, 0f, 0f, 0.1f);

    PLAYER player;

    bool isDead;

    bool damage;
    bool life;

    private GAMEMANAGER gameManager;

    void Awake()
    {
        player = GetComponent<PLAYER>();

        currentHealth = startingHealth;

        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();

        // Update life UI
        gameManager.PlayerLife(currentHealth);
    }

    void Update()
    {
        
        if (damage)
        {
            damageImage.color = flashColour;
        }

        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damage = false;

        /*if (life)
        {
            lifeImage.color = flashColourLife;
        }

        else
        {
            lifeImage.color = Color.Lerp(lifeImage.color, Color.clear, flashSpeedLife * Time.deltaTime);
        }*/

        //life = false;
    }

    public void TakeDamage(int amount)
    {
        damage = true;
        currentHealth -= amount;
        //Pain.Play();

        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            Death();
        }

        // Update life UI
        gameManager.PlayerLife(currentHealth);
    }

    public void TakeLife(int amount)
    {
        life = true;
        currentHealth += amount;
        
        if (currentHealth >= 12)
        {
            currentHealth = 12;
        }

        // Update life UI
        gameManager.PlayerLife(currentHealth);
    }

    void Death()
    {
        isDead = true;

        player.enabled = false;

        anim.SetTrigger("isDead");

        //SceneManager.LoadScene();
        
        //playerAudio.Play();
    }
}