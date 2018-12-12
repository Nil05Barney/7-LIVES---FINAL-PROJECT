using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBackground : MonoBehaviour
{
    public AudioSource fondoSFX;
    public AudioSource musicfondoSFX;

    // Use this for initialization
    void Start ()
    {
        fondoSFX.Play();
        musicfondoSFX.Play();
	}

}
