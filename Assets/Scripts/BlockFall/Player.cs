using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{
    public string lastDirection;
    public SkinnedMeshRenderer[] Skins;
    float playerSpeed=.005f;
    Animator animator;
    GameBoard gameBoard;
    int lives=1;
    Vector2 moveVal= Vector2.zero;
    bool canAct = false;


    void Start(){
        animator = GetComponent<Animator>();
        gameBoard = GameObject.Find("SCRIPTRUNNER").GetComponent<GameBoard>();
        StartCoroutine(freezeinPlace(10));
    }

    void Update(){
        if (!canAct){
            return;
        }
        if(moveVal==Vector2.up){
            moveUp();
        }
        if(moveVal==Vector2.zero){
            idle();
        }
        if(moveVal==Vector2.down){
            moveDown();
        }
        if(moveVal==Vector2.left){
            moveLeft();
        }        
        if(moveVal==Vector2.right){
            moveRight();
        }        
        if(this.gameObject.transform.position.y<-15){//player fell
            lives-=1;
            if(lives>0){
                Debug.Log("RespawnPlayer");
                respawnPlayer();
                StartCoroutine(setInvincibleFrames());
            }else{
                Debug.Log("DeadPlayer");
                gameBoard.deadPlayer();
                disableActions();
            }
        }
    }


    
    public void OnMovement(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    public void OnAttack(){
        if(animator.GetBool("Attack")==false  && lives!=0){      
            animator.SetBool("Attack",true);
            gameBoard.dropBlocks(lastDirection,(this.gameObject.transform.position.x,this.gameObject.transform.position.z));
            StartCoroutine(freezeinPlace(1));
        }
    }

    public void moveUp(){
        if(animator.GetBool("Attack")==false && lives!=0){    
             this.gameObject.transform.position += new Vector3(0,0,playerSpeed);
            lastDirection="North";
             this.gameObject.transform.eulerAngles = new Vector3(0,0,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveDown(){
        if(animator.GetBool("Attack")==false  && lives!=0){      
             this.gameObject.transform.position += new Vector3(0,0,-playerSpeed);
            lastDirection="South";
             this.gameObject.transform.eulerAngles = new Vector3(0,180,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveLeft(){
        if(animator.GetBool("Attack")==false  && lives!=0){    
             this.gameObject.transform.position += new Vector3(-playerSpeed,0,0);
            lastDirection="West";       
             this.gameObject.transform.eulerAngles = new Vector3(0,270,0);
            animator.SetBool("Walk",true);
        }
    }
    public void moveRight(){
        if(animator.GetBool("Attack")==false  && lives!=0){    
             this.gameObject.transform.position += new Vector3(playerSpeed,0,0);
            lastDirection="East";
             this.gameObject.transform.eulerAngles = new Vector3(0,90,0);
            animator.SetBool("Walk",true);
        }
    }
    public void idle(){
        animator.SetBool("Walk",false);
    }

    public void enableActions(){
        canAct = true;
    }

    public void disableActions(){
        canAct = false;
    }

    IEnumerator freezeinPlace(int seconds){
        bool run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(seconds);
        }
        animator.SetBool("Attack",false);
    }
    IEnumerator setInvincibleFrames(){
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;;
        for (int i = 0; i<20; i++){
            if (i%2 == 0){
                foreach (SkinnedMeshRenderer Skin in Skins){
                    Skin.enabled = false;
                }
            }
            else{
                foreach (SkinnedMeshRenderer Skin in Skins){
                    Skin.enabled = true;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void respawnPlayer(){
        int x;
        int y;
        while(true){
            x = Random.Range(0, 7);
            y = Random.Range(0, 7);
            if(gameBoard.gameBoard[x,y]==0){
                break;
            }
        }
        this.gameObject.transform.position = new Vector3((float) x,0.5f,(float) y);
    }
}    
