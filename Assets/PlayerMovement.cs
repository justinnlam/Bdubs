 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rb;
    //float mspeed = 6f;
    GameBoard gameBoard;
    Player player2;
    Player player;
    Material DropWarning;
    Material even;
    Material odd;
    int attackTime;
    void Start()
    {

        DropWarning = Resources.Load("DropWarning", typeof(Material)) as Material;
        odd = Resources.Load("even", typeof(Material)) as Material;
        even = Resources.Load("odd", typeof(Material)) as Material;
        gameBoard = gameObject.AddComponent<GameBoard>();
        player = gameObject.AddComponent<Player>();
        player2 = gameObject.AddComponent<Player>();
        player.init("Player",(0, 0), new Vector3(0,.5f,0),"North");    
        player2.init("Player2",(7, 7), new Vector3(7,.5f,7),"South");
        attackTime=0;
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);
        gameBoard.recalculateCubes(DropWarning,even,odd);
        if(attackTime==60){
            attackTime=0;
            player.endAttack();
        }else if(attackTime>0){
            attackTime++;
        }
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
        if (Input.GetKeyDown("space")) {//remove else here
            gameBoard.dropBlocks(player.lastDirection,player.playerPos);
            player.attack();
            attackTime=1;
        }        
        if(!Input.anyKey){
            player.idle();
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
        }        

        if (Input.GetKeyDown(KeyCode.Return)) {
            gameBoard.dropBlocks(player2.lastDirection,player2.playerPos);
        }
        if (Input.GetKey(KeyCode.R)) {
            Debug.Log("x"+player.playerPos.x);
            Debug.Log("y"+player.playerPos.y);
        }
    }       
}
