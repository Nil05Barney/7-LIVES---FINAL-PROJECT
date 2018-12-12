using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relotge : MonoBehaviour
{
    public int extraTime;
    private bool destroy;
    private TimeCounter timeCounter;
    private PLAYER_VIDA playerVida;

    public AudioSource powerUp;

    public void Start()
    {
        timeCounter = GameObject.FindGameObjectWithTag("TIME").GetComponent<TimeCounter>();
        playerVida = GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER_VIDA>();

        destroy = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            powerUp.Play();

            timeCounter.SumarTiempo();
            playerVida.TakeLife();
            
            // Note: Destroy for testing
            Destroy(this.gameObject);
            destroy = true;
        }
    }
}
