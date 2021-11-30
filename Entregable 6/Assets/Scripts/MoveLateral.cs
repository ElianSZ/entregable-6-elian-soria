using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public float speed = 5f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Estamos accediendo a las variables del script PlayerController, en concreto, a la variable GameOver
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
