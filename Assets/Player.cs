using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    (double x, double y) playerPos;
    string lastDirection;
    float playerSpeed=.007f;
    Animator animator;
    bool attackFrozen;
    GameBoard gameBoard;
    void Start(){
        animator = GetComponent<Animator>();
        gameBoard = GameObject.Find("ScriptRunner").GetComponent<GameBoard>();
        playerPos=( this.gameObject.transform.position.x, this.gameObject.transform.position.z);
    }
    public void moveUp(){
        if(attackFrozen==false){
             this.gameObject.transform.position += new Vector3(0,0,playerSpeed);
            playerPos.y+=playerSpeed;
            lastDirection="North";
             this.gameObject.transform.eulerAngles = new Vector3(0,0,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveDown(){
        if(attackFrozen==false){    
             this.gameObject.transform.position += new Vector3(0,0,-playerSpeed);
            playerPos.y-=playerSpeed;
            lastDirection="South";
             this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveLeft(){
        if(attackFrozen==false){    
             this.gameObject.transform.position += new Vector3(-playerSpeed,0,0);
            playerPos.x-=playerSpeed;
            lastDirection="West";       
             this.gameObject.transform.eulerAngles = new Vector3(0,270,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveRight(){
        if(attackFrozen==false){
             this.gameObject.transform.position += new Vector3(playerSpeed,0,0);
            playerPos.x+=playerSpeed;    
            lastDirection="East";
             this.gameObject.transform.eulerAngles = new Vector3(0,90,0);
            animator.SetBool("Walk",true);
        }
    }
    public void idle(){
        animator.SetBool("Walk",false);
    }
    public void attack(){
        if(attackFrozen==false){    
            animator.SetBool("Attack",true);
            gameBoard.dropBlocks(lastDirection,playerPos);
            StartCoroutine(freezeinPlace());
        }
    }
    IEnumerator freezeinPlace(){
        bool run=false;
        if(run==false){
            attackFrozen=true;
            run=true;
            yield return new WaitForSeconds(1);
        }
        attackFrozen=false;
        animator.SetBool("Attack",false);
    }
}    
//float mspeed = 6f;
//float horizontalInput = Input.GetAxis("Horizontal");
//float verticalInput = Input.GetAxis("Vertical");
//rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);