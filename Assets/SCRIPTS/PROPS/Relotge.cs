using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relotge : MonoBehaviour
{
    public int extraTime;

    private bool destroy;

    public void Start()
    {
        if (destroy)
        {
            GetComponent<TimeCounter>().ExtraTime(extraTime);
        }

        destroy = false;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Note: Destroy for testing
            Destroy(this.gameObject);
            destroy = true;
        }
    }
}
