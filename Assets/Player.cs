using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    (int x, int y) spawnPoint; 
    public string lastDirection;
    public SkinnedMeshRenderer[] Skins;
    float playerSpeed=.008f;
    Animator animator;
    GameBoard gameBoard;
    public int lives;
    [SerializeField]
    private GameObject[] spriteLives;

    void Start(){
        animator = GetComponent<Animator>();
        gameBoard = GameObject.Find("ScriptRunner").GetComponent<GameBoard>();
        spawnPoint=((int) this.gameObject.transform.position.x,(int) this.gameObject.transform.position.z);
    }
    void Update(){
        if(this.gameObject.transform.position.y<-15 && lives!=-1){
            lives-=1;
            spriteLives[lives].GetComponent<Image>().enabled = false;
            if(lives!=0){
                //this.gameObject.transform.position = new Vector3((float) spawnPoint.x,0.5f,(float) spawnPoint.y);
                //spawn in random spot? 
                spawnPlayer();
                StartCoroutine(setInvincibleFrames());
            }else{
                  gameBoard.deadPlayer();
            }
        }
    }
    public void spawnPlayer(){
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
    public void attack(){
        if(animator.GetBool("Attack")==false  && lives!=0){      
            animator.SetBool("Attack",true);
            gameBoard.dropBlocks(lastDirection,(this.gameObject.transform.position.x,this.gameObject.transform.position.z));
            StartCoroutine(freezeinPlace());
        }
    }
    IEnumerator freezeinPlace(){
        bool run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(1);
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
}    

//float mspeed = 6f;
//float horizontalInput = Input.GetAxis("Horizontal");
//float verticalInput = Input.GetAxis("Vertical");
//rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);