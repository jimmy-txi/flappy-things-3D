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
    Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z), 0.1f);

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
            player.AddForce(Vector2.up * 250);
            if (player.velocity.y > 5)
            {
                player.velocity = new Vector2(player.velocity.x, 5);
                
            }
        }
    }
}

