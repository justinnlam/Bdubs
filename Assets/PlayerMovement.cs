 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player;    
    Player player2;
    Player player3;

    void Start(){
        player = GameObject.Find("Player").GetComponent<Player>();
        player2 = GameObject.Find("Player2").GetComponent<Player>();   
        player3 = GameObject.Find("Player3").GetComponent<Player>();
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
        
        if (Input.GetKeyDown(KeyCode.P)) {
            player3.attack();
        }
        else if (Input.GetKey(KeyCode.I)){
            player3.moveUp();
        }
        else if (Input.GetKey(KeyCode.J)){
            player3.moveLeft();
        }
        else if (Input.GetKey(KeyCode.L)){
            player3.moveRight();
        }
        else if (Input.GetKey(KeyCode.K)){
            player3.moveDown();
        }        
        else{
            player3.idle();
        }


    
        
    }       
}
