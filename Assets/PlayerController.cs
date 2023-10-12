using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    float maxspeed = 5.0f;
    bool isOnGround = false;
    float jumpforce = 1.0f;

    //create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;
    // Start is called before the first frame update
    void Start()
    {
        //Find the rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Create a 'float' that will be equal to the players horizontal input
        float movementValueX = 1.0f;
        //change the X velocity of the Rigidbody2D to be equal to the movement vall
        playerObject.velocity = new Vector2(movementValueX*5, playerObject.velocity.y);

        //check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        if ((isOnGround == true) && (Input.GetAxis("Jump") > 0.0f))
        {

            playerObject.AddForce(Vector2.up * jumpforce);

        }
    }
}

