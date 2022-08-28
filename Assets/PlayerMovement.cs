 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rb;
    //float mspeed = 6f;
    GameBoard gameBoard = new GameBoard();
    Player player2 = new Player();
    Player player = new Player();

    void Start()
    {
        player.init("Player",(0, 0), new Vector3(0,1,0),"North");    
        player2.init("Player2",(7, 7), new Vector3(7,1,7),"South");

    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);
        gameBoard.recalculateCubes();
        //Debug.Log(gameBoard[0,0]);

        if (Input.GetKey("w")){
            player.moveUp();
        }
        else if (Input.GetKey("a")){
            player.moveLeft();
        }
        else if (Input.GetKey("d")){
            player.moveRight();
        }
        else if (Input.GetKey("s")){
            player.moveDown();
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            player2.moveUp();
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            player2.moveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            player2.moveRight();
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
            player2.moveDown();
            Debug.Log(player2.playerPos.x);
        }        
        if (Input.GetKeyDown("space")) {
            gameBoard.dropBlocks(player.lastDirection,player.playerPos);
        }
        if (Input.GetKey(KeyCode.R)) {
            Debug.Log("x"+player.playerPos.x);
            Debug.Log("y"+player.playerPos.y);
        }
    }       
}
