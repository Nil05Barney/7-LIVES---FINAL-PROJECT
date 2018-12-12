using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objToSpawn;
    public float minTime;
    public float maxTime;
    public float deltaPosY;
    private float timeCounter;
    private float timeSpawn;

    public Vector3 rotacionTronco;

    void Start()
    {
        timeSpawn = minTime;
        timeCounter = 0;
    }
    void Update()
    {
        if (timeCounter >= timeSpawn)
        {
            Spawnation();
        }
        else timeCounter += Time.deltaTime;
    }
    void Spawnation()
    {
        timeCounter = 0;
        timeSpawn = Random.Range(minTime, maxTime);

        Vector3 spawnPos = transform.position;
        spawnPos.y += Random.Range(deltaPosY, deltaPosY);

        GameObject obj = Instantiate(objToSpawn, spawnPos, Quaternion.Euler(rotacionTronco));
        obj.name = objToSpawn.name + "_" + Time.time.ToString("00.00");
    }
}
