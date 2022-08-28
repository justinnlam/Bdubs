using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rb;
    //float mspeed = 6f;
    int[,] gameBoard = new int[8,8];
    // Start is called before the first frame update
    Player player2 = new Player();
    Player player = new Player();

    void Start()
    {
        player2.init("Player2",(7, 7), new Vector3(7,1,7));
        player.init("Player",(0, 0), new Vector3(0,1,0));
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                gameBoard[i,j]=0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector3(horizontalInput*mspeed, rb.velocity.y, verticalInput * mspeed);
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                if(gameBoard[i,j]==600){
                    int x=i+1;
                    int y=j+1;
                    GameObject cube = GameObject.Find("Cube"+x+y);                      
                    Destroy(cube.GetComponent<Rigidbody>());
                    cube.transform.position=new Vector3(x,0,y);
                    gameBoard[i,j]=0;
                }
                else if(gameBoard[i,j]>0){
                    gameBoard[i,j]+=1;
                }
            }
        }
        //Debug.Log(gameBoard[0,0]);
        if (Input.GetKeyDown("space")) {
            allfall();
        }
        if (Input.GetKeyDown("w")){
            player.moveUp();
        }
        else if (Input.GetKeyDown("a")){
            player.moveLeft();
        }
        else if (Input.GetKeyDown("d")){
            player.moveRight();
        }
        else if (Input.GetKeyDown("s")){
            player.moveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            player2.moveUp();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            player2.moveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            player2.moveRight();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            player2.moveDown();
            Debug.Log(player2.playerPos.x);
        }        
    }       
 
    void floorfall()
    {
    int x = Random.Range(1, 8);
    int y = Random.Range(1, 8);
    GameObject cube = GameObject.Find("Cube"+x+y);  
    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>(); // Add the rigidbody.
    }
    void allfall(){
              for(int i=0;i<8;i++){
                for(int j=0;j<8;j++){
                    int x=i+1;
                    int y=j+1;
                    GameObject cube = GameObject.Find("Cube"+x+y);  
                    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();   
                    gameObjectsRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;           
                    gameBoard[i,j]=1;
                }
              }
    }
}
