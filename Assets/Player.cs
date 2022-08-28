using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    // Start is called before the first frame update
    public GameObject CurrentPlayer;
    public (double x, double y) playerPos;
    public string lastDirection;
    public float playerSpeed=.007f;

    public void init(string objectToFind, (int x, int y) playerPosInit , Vector3 position,string startingDirection){
        CurrentPlayer = GameObject.Find(objectToFind); 
        CurrentPlayer.transform.position = position;
        this.playerPos=playerPosInit;
        lastDirection=startingDirection;
    }
    public void moveUp(){
        CurrentPlayer.transform.position += new Vector3(0,0,playerSpeed);
        playerPos.y+=playerSpeed;
        lastDirection="North";
    }
    public void moveDown(){
        CurrentPlayer.transform.position += new Vector3(0,0,-playerSpeed);
        playerPos.y-=playerSpeed;
        lastDirection="South";
    }
    public void moveLeft(){
        CurrentPlayer.transform.position += new Vector3(-playerSpeed,0,0);
        playerPos.x-=playerSpeed;
        lastDirection="West";
    }
    public void moveRight(){
        CurrentPlayer.transform.position += new Vector3(playerSpeed,0,0);
        playerPos.x+=playerSpeed;    
        lastDirection="East";
    }
}
