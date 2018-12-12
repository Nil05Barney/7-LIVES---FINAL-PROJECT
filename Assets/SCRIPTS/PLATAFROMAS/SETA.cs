using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETA : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("SETAJUMP", true);
            other.GetComponent<PLAYER>().SetaJump();
        }


    }
}
