using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject CurrentPlayer;
    public (double x, double y) playerPos;
    public string lastDirection;
    public float playerSpeed=.007f;
    public Animator animator;

    public void init(string objectToFind, (int x, int y) playerPosInit , Vector3 position,string startingDirection){
        CurrentPlayer = GameObject.Find(objectToFind); 
        CurrentPlayer.transform.position = position;
        this.playerPos=playerPosInit;
        lastDirection=startingDirection;
        animator = GetComponent<Animator>();
    }
    public void moveUp(){
        CurrentPlayer.transform.position += new Vector3(0,0,playerSpeed);
        playerPos.y+=playerSpeed;
        lastDirection="North";
        CurrentPlayer.transform.eulerAngles = new Vector3(0,0,0);
        animator.SetBool("Walk",true);
    }
    public void moveDown(){
        CurrentPlayer.transform.position += new Vector3(0,0,-playerSpeed);
        playerPos.y-=playerSpeed;
        lastDirection="South";
        CurrentPlayer.transform.eulerAngles = new Vector3(0,180,0);
        animator.SetBool("Walk",true);

    }
    public void moveLeft(){
        CurrentPlayer.transform.position += new Vector3(-playerSpeed,0,0);
        playerPos.x-=playerSpeed;
        lastDirection="West";       
        CurrentPlayer.transform.eulerAngles = new Vector3(0,270,0);
        animator.SetBool("Walk",true);

    }
    public void moveRight(){
        CurrentPlayer.transform.position += new Vector3(playerSpeed,0,0);
        playerPos.x+=playerSpeed;    
        lastDirection="East";
        CurrentPlayer.transform.eulerAngles = new Vector3(0,90,0);
        animator.SetBool("Walk",true);
    }
    public void idle(){
        animator.SetBool("Walk",false);
    }
    public void attack(){
        animator.SetBool("Attack",true);
    }
    public void endAttack(){
        animator.SetBool("Attack",false);
    }

}
