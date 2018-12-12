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
    public Image lifeImage;
    public Image timeExtraImage;

    public AudioSource Pain;

    public float flashSpeed = 5f;
    public float flashSpeedLife = 15f;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color flashColourLife = new Color(1f, 0f, 0f, 0.1f);
    public Color flashColourLifeTime = new Color(1f, 0f, 0f, 0.1f);

    PLAYER player;

    bool isDead;

    public bool damage;
    public bool life;
    public bool timeExtra;

    private GAMEMANAGER gameManager;

    public float PosX;
    public float PosY;
    public float PosZ;

    public Vector3 Posicion;

    private TimeCounter timeCounter;

    public void Ini()
    {
        player = GetComponent<PLAYER>();
        Guardar_Posicion();
        currentHealth = startingHealth;

        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();

        timeCounter = GameObject.FindGameObjectWithTag("TIME").GetComponent<TimeCounter>();

        // Update life UI
        gameManager.PlayerLife(currentHealth);
    }

    public void Update()
    {
        if (damage)
        {
            damageImage.color = flashColour;
        }

        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if (life)
        {
            lifeImage.color = flashColourLife;
        }

        else
        {
            lifeImage.color = Color.Lerp(lifeImage.color, Color.clear, flashSpeedLife * Time.deltaTime);
        }

        if (timeExtra)
        {
            timeExtraImage.color = flashColourLife;
        }

        else
        {
            timeExtraImage.color = Color.Lerp(lifeImage.color, Color.clear, flashSpeedLife * Time.deltaTime);
        }


        damage = false;
        life = false;
        timeExtra = false;
    }

    public void TakeDamage(int amount)
    {
        //smoothCamera.CameraDamage();
        damage = true;
    
        if (damage && currentHealth > 1)
        {
            Cargar_Posicion(); 
            timeCounter.ResetTiempo(); 
        }

        currentHealth -= amount;
        Pain.Play();

        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0;
            Death();
        }

        // Update life UI
        gameManager.PlayerLife(currentHealth);
    }

    public void TakeLife()
    {
        life = true;
    }

    public void Death()
    {
        Debug.Log("MOOOOORT");
        isDead = true;

        player.enabled = false;

        anim.SetTrigger("isDead");

        SceneManager.LoadScene(5);
    }
    
    public void Guardar_Posicion()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
    }

    public void Cargar_Posicion()
    {
        PosX = PlayerPrefs.GetFloat("x");
        PosY = PlayerPrefs.GetFloat("y");
        PosZ = PlayerPrefs.GetFloat("z");

        Posicion.x = PosX;
        Posicion.y = PosY;
        Posicion.z = PosZ;

        transform.position = Posicion;

    }

}