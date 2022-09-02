using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    (double x, double y) initPlayerPos;   //delete after changing to spawn random blocks 
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
        initPlayerPos=(this.gameObject.transform.position.x, this.gameObject.transform.position.z);
    }
    void Update(){
        if(this.gameObject.transform.position.y<-15){
            if(lives!=0){
                lives-=1;
                gameBoard.deadPlayer();
            } 
            //UnityEngine.Object.Destroy(spriteLives[lives].GetComponent<Image>());
            spriteLives[lives].GetComponent<Image>().enabled = false;
            if(lives!=0){
                this.gameObject.transform.position= new Vector3((float) initPlayerPos.x,0.5f,(float) initPlayerPos.y);
       
                //spawn in random spot? 
                StartCoroutine(invincibleFrames());
            }else{
                //UnityEngine.Object.Destroy(this.gameObject.GetComponent<Rigidbody>());
                //this.gameObject.transform.position= new Vector3(0,10,0);         
            }
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
    IEnumerator invincibleFrames(){
        bool run=false;
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;;
        for (int i = 0; i<20; i++){
            if (i%2 == 0){
                foreach (SkinnedMeshRenderer Skin in Skins)
                {
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