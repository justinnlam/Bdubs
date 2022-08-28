using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    // Start is called before the first frame update
    public GameObject CurrentPlayer;
    public (int x, int y) playerPos;
    public string lastDirection;

    public void init(string objecttoFind, (int x, int y) playerPosInit , Vector3 position){
        CurrentPlayer = GameObject.Find(objecttoFind); 
        CurrentPlayer.transform.position = position;
        this.playerPos=playerPosInit;
        lastDirection="North";
    }
    public void moveUp(){
        CurrentPlayer.transform.position += Vector3.forward;
        playerPos.y+=1;
        lastDirection="North";
    }
    public void moveDown(){
        CurrentPlayer.transform.position += Vector3.back;
        playerPos.y-=1;
        lastDirection="South";
    }
    public void moveLeft(){
        CurrentPlayer.transform.position += Vector3.left;
        playerPos.x-=1;
        lastDirection="West";
    }
    public void moveRight(){
        CurrentPlayer.transform.position += Vector3.right;
        playerPos.x+=1;    
        lastDirection="East";
    }
}
