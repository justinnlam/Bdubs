 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player2;
    Player player;
    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
        player2 = GameObject.Find("Player2").GetComponent<Player>();    
    }

    void Update(){
        if (Input.GetKeyDown("space")) {//remove else here
            player.attack();
        }               
        else if (Input.GetKey("w")){
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
        else{
            player.idle();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            player2.attack();
        }
        else if (Input.GetKey(KeyCode.UpArrow)){
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
        else{
            player2.idle();
        }
        




        
    }       
}
