using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DEADBUTTONS : MonoBehaviour
{
    public void Home(int num)
    {
        Time.timeScale = 1;
        Debug.Log("HOOOOMEEEEE" + num);
        SceneManager.LoadScene(1);
    }

}
