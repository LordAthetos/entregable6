using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    public float jumpForce = 5f;
    public float gravityModifier = 0.9f;
    private float yRange = 14f;

    public bool gameOver;

    public ParticleSystem explosionParticleSystem;

    public AudioClip jumpClip;
    public AudioClip explosionClip;

    
    void Start()
    {
    // Accedemos a los componentes 

        playerRigidbody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    
    void Update()
    {
        // Salto 
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 1);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        // Detectar colisiones y game Over
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {                               
                gameOver = true;
            }
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                
                // Activar sistema de partículas de explosión
                explosionParticleSystem.Play();
                                
                // Bajamos volumen de la música
                cameraAudioSource.volume = 0.01f;
                // SFX de explosión
                playerAudioSource.PlayOneShot(explosionClip, 1);
                
                // Comunicamos que hemos muerto
                gameOver = true;
            }
        }

    }
}
