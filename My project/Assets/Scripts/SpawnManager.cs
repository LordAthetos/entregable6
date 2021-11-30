using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private Vector3 spawnPos;
    private float randomHeight;
    private int leftOrRight;
    private PlayerController playerControllerScript;
    private int minY = 2;
    private int maxY = 14;
    private int spawnPosX = 16;
  
    void Start()
    {
        // Repetimos la funcion
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void SpawnObstacle()
    {
        // Spawneamos un obstaculo a uno de los lados de la pantalla
        if (!playerControllerScript.gameOver)
        {
            leftOrRight = Random.Range(0,2);
            randomHeight = Random.Range(minY,maxY);
            if (leftOrRight == 0)
            {
                spawnPos = new Vector3(-spawnPosX, randomHeight, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            }
            else 
            {
                spawnPos = new Vector3(spawnPosX, randomHeight, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            }
          
        }
    }
}
