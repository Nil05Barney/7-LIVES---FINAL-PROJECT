using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinxosAnimados : MonoBehaviour
{
    public int attackDamage = 1;
    public float timePinxos = 4f;

    private float timeSalirPinxos;
    private float timeCounter;

    public AudioSource pinxosSFX;

    private GAMEMANAGER gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GAMEMANAGER").GetComponent<GAMEMANAGER>();

        timeSalirPinxos = timePinxos;
        timeCounter = 0;
    }

    private void Update()
    {
       
        if (timeCounter >= timeSalirPinxos && !gameManager.isPauuuse) 
        {
            pinxosSFX.Play();
            timeCounter = 0;
        }

        else timeCounter += Time.deltaTime;

        if (gameManager.isPauuuse)
        {
            pinxosSFX.Pause();
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PLAYER_VIDA>().TakeDamage(attackDamage);
            other.GetComponent<PLAYER>().PinxosDamageEfect();
        }
    }
}
