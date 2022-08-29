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
        CurrentPlayer.transform.eulerAngles = new Vector3(0,0,0);
    }
    public void moveDown(){
        CurrentPlayer.transform.position += new Vector3(0,0,-playerSpeed);
        playerPos.y-=playerSpeed;
        lastDirection="South";
        CurrentPlayer.transform.eulerAngles = new Vector3(0,180,0);
    }
    public void moveLeft(){
        CurrentPlayer.transform.position += new Vector3(-playerSpeed,0,0);
        playerPos.x-=playerSpeed;
        lastDirection="West";       
        CurrentPlayer.transform.eulerAngles = new Vector3(0,270,0);

    }
    public void moveRight(){
        CurrentPlayer.transform.position += new Vector3(playerSpeed,0,0);
        playerPos.x+=playerSpeed;    
        lastDirection="East";
        CurrentPlayer.transform.eulerAngles = new Vector3(0,90,0);
    }


    /*IEnumerator rotate(Integer endDegree,){
        for(int i=playerPos.x-1;i>-1;i--){
                yield return new WaitForSeconds(.1f);
        }
    }*/      
}
