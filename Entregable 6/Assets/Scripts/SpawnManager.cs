using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 1.8f;
    private float repeatRate = 1.4f;
    private Vector3 randomPos;
    private float spawnPos;
    // private Vector3 spawnPosL;
    private float randomHeight;
    private float limY = 14f;
    private PlayerController playerControllerScript;
    public GameObject[] obstaclePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Repetimos la función SpawnObstacle cada 1.4 segundos
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObstacle()
    {
        // Estamos accediendo a las variables del script PlayerController, en concreto, a la variable GameOver
        if (!playerControllerScript.gameOver)
        {
            randomHeight = Random.Range(-limY, limY);
            spawnPos = Random.Range(0, 2);

            if (spawnPos == 0)
            {
                randomPos = new Vector3(-13, randomHeight, 0);
                Instantiate(obstaclePrefabs[1], randomPos, obstaclePrefabs[1].transform.rotation);
            }

            if (spawnPos == 1)
            {
                randomPos = new Vector3(13, randomHeight, 0);
                Instantiate(obstaclePrefabs[0], randomPos, obstaclePrefabs[0].transform.rotation);
            }

           
            
            // spawnPosR = new Vector3(-15, randomHeight, 0);

            // obstaclePrefabs.Length = indica la longitud máxima de prefabs que he puesto en SpawnManager
            
            
            // Instantiate(obstaclePrefabs[randomIndex], spawnPosR, obstaclePrefabs[randomIndex].transform.rotation);
            
        }
    }
}


/*
n = Random.Range(0,2);
if (n == 0)
{
    n = -1
}


spawnPos = Random.Range(0,2);
if (spawnPos == 0)
{
    spawnPos = -1
}
*/