using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private bool isLeft;
    private bool isRight;
    private Rigidbody player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PipeTop") || other.CompareTag("PipeBottom") || other.CompareTag("Ground"))
        {
            Debug.Log("Touched a pipe! Informing GameManager...");
            GameManager.Instance.KillPlayer(); // Appelle la fonction du GameManager
        }
    }

    private void KillPlayer()
    {
        // Logique pour gérer la mort du joueur
        Debug.Log("Player has been killed!");
        gameObject.SetActive(false); // Désactiver le joueur
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    //  Make follow camera too player and lerp movement
    // move player to right
    // transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);

    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x+15, transform.position.y+15, Camera.main.transform.position.z), 1f);

    // player Controls
    if (Input.GetKeyDown(KeyCode.Space)) isJumped = true;
    if (Input.GetKeyDown(KeyCode.LeftArrow)) isLeft = true;
    if (Input.GetKeyDown(KeyCode.RightArrow)) isRight = true;

    // scene reloader
    if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // fixed Update function
    void FixedUpdate()
    {
        if (isJumped)
        {   
            isJumped = false;
            if (player.transform.position.y < 30)
            {   
                player.velocity = new Vector2(0,0);            
                player.AddForce(Vector2.up * 350);
                // apply for rotate player arond his origin like rotate excentred force
                player.AddTorque(Vector3.up * Random.Range(-5f, 5f));
                player.AddTorque(Vector3.right * Random.Range(-5f, 10f));
                player.AddTorque(Vector3.forward * Random.Range(-5f, 10f));

            }

            if (player.velocity.y > 20)
            {
                player.velocity = new Vector2(player.velocity.x, 20);
                
            }
        }
        if (isLeft)
        {
            isLeft = false;
            player.AddTorque(Vector3.forward * 50);
        }
        if (isRight)
        {
            isRight = false;
            player.AddTorque(Vector3.forward * -50);
        }
    }
}

