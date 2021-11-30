using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
     public float speed = 5f;

     private PlayerController playerControllerScript;
     private float spawnSide;
     private bool direccion;
    


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       // Comprobamos en que direccion de la pantalla ha spaweado el obstaculo
        spawnSide = transform.position.x;
        if (spawnSide < 0) 
        {
            direccion = true;
        }
         if (spawnSide > 0) 
        {
            direccion = false;
        }
    }
    void Update()
    {
        // Movemos el obstaculo en la direccion contraria de la que ha spawneado
         if (!playerControllerScript.gameOver && direccion)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (!playerControllerScript.gameOver && !direccion)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        // Hacemos desaparecer el obstaculo en el lado opuesto de la pantalla
        if (transform.position.x == spawnSide * -1)
        {
            Destroy(gameObject);
        } 

    } 
}
