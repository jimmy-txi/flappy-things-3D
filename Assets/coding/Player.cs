using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJumped;
    private Rigidbody player;

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
    transform.position = new Vector3(transform.position.x + 0.02f, transform.position.y, transform.position.z);

    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x+8, transform.position.y+5, Camera.main.transform.position.z), 0.1f);

    if (Input.GetKeyDown(KeyCode.Space))
    {
        isJumped = true;
    }
    }

    // fixed Update function
    void FixedUpdate()
    {
        if (isJumped)
        {
            isJumped = false;
                player.velocity = new Vector2(0,0);            
            player.AddForce(Vector2.up * 350);

            if (player.velocity.y > 20)
            {
                player.velocity = new Vector2(player.velocity.x, 20);
                
            }
        }
    }
}

