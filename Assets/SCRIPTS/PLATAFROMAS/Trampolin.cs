using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public Animator anim;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("MUELLE", true);
            other.GetComponent<PLAYER>().MuelleJump();

        }
    }
}
