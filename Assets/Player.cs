using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    // Start is called before the first frame update
    public GameObject CurrentPlayer;
    public (int x, int y) playerPos;

    public void init(string objecttoFind, (int x, int y) playerPosInit , Vector3 position){
        CurrentPlayer = GameObject.Find(objecttoFind); 
        CurrentPlayer.transform.position = position;
        this.playerPos=playerPosInit;
    }
    public void moveUp(){
        CurrentPlayer.transform.position += Vector3.forward;
        playerPos.x+=1;
    }
    public void moveDown(){
        CurrentPlayer.transform.position += Vector3.back;
        playerPos.x-=1;
    }
    public void moveLeft(){
        CurrentPlayer.transform.position += Vector3.left;
        playerPos.y-=1;
    }
    public void moveRight(){
        CurrentPlayer.transform.position += Vector3.right;
        playerPos.y+=1;    
    }
}
