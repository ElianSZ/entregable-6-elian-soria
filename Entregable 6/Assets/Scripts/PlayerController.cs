using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    private Rigidbody playerRigidBody;
    private float gravityModifier;
    private float jumpForce = 25;
    private float yRange = 14f;
    private float lowerLim = 0f;
    public bool gameOver;
    public ParticleSystem explosionParticleSystem;
    public AudioClip JumpClip;
    public AudioClip ExplosionClip;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            playerAudioSource.PlayOneShot(JumpClip, 1f);                                                                // Ejecuta una vez el audio de saltar
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange,
                transform.position.z);
        }

        if (transform.position.y < lowerLim)
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER");
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        // Si no estamos muertos, ejecuta todo
        if (!gameOver)
        {
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);       // Instancia el efecto de explosión
            playerAudioSource.PlayOneShot(ExplosionClip, 1f);                                                           // Ejecuta una vez el audio de explosión

            cameraAudioSource.volume = 0.1f;                                                                            // Baja el volumen de la música

            Destroy(gameObject);

            // Comunica que hemos muerto
            gameOver = true;
            Debug.Log(message: "GAME OVER");
            /*
            Time.timeScale = 0;
            */
        }
    }
}
