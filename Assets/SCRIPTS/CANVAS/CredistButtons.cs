using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CredistButtons : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject creditsPanel;

    public void Return()
    {
        Debug.Log("RETURN");
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

}
