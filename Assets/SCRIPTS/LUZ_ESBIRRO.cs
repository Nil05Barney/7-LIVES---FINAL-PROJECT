using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LUZ_ESBIRRO : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("esbirro pirate ijuepta");
            Destroy(GameObject.FindWithTag("ESBIRRO_AZUL"));
        }
    }
}
