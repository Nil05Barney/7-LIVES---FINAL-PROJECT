using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PINXOS : MonoBehaviour
{
    public int attackDamage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PLAYER_VIDA>().TakeDamage(attackDamage);
            other.GetComponent<PLAYER>().PinxosDamageEfect();
        }
    }
}
