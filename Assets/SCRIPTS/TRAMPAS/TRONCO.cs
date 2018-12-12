 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRONCO : MonoBehaviour
{
    public int attackDamage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PLAYER_VIDA>().TakeDamage(attackDamage);
            other.GetComponent<PLAYER>().PinxosDamageEfect();
            Destroy(gameObject, 1);
        }

        if (other.tag == "Destroier")
        {
            Debug.Log("Destroy?");
            Destroy(gameObject, 1);
        }
    }
}
