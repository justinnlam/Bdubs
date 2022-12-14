using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBoard : MonoBehaviour{
    public double[,] gameBoard = new double[8,8];
    public int reappearTime=1000;
    public int dropTime=200;
    Material even;
    Material odd;
    Material dw;
    public int numPlayers;
    public int deadPlayers=0;

    void Start(){
        dw = Resources.Load("DropWarning", typeof(Material)) as Material;
        odd = Resources.Load("even", typeof(Material)) as Material;
        even = Resources.Load("odd", typeof(Material)) as Material;    
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                gameBoard[i,j]=0;
            }
        }          
    }
    void Update(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                GameObject cube = GameObject.Find("Cube"+i+j);      
                //Cube reappears
                if(gameBoard[i,j]==-1){
                    continue;
                }
                else if(gameBoard[i,j]==reappearTime){
                    if((i+j)%2==0){
                        cube.GetComponent<MeshRenderer>().material = even;                    
                    } 
                    else {
                        cube.GetComponent<MeshRenderer>().material = odd;
                    }
                    UnityEngine.Object.Destroy(cube.GetComponent<Rigidbody>());
                    cube.transform.position=new Vector3(i,0,j);
                    gameBoard[i,j]=0;                    
                }
                //drop Cube permanently
                else if(gameBoard[i,j]==dropTime+.5){
                    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                    gameBoard[i,j]=-1;
                }
                //drop
                else if(gameBoard[i,j]==dropTime){
                    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                    gameObjectsRigidBody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY; 
                    gameBoard[i,j]+=1;
                }                
                //Cubes turn black
                else if(gameBoard[i,j]>0){
                    gameBoard[i,j]+=1;
                    cube.GetComponent<MeshRenderer>().material = dw;                    
                }
            }
        }
        
    }
    public void deadPlayer(){
        deadPlayers+=1;
        if(deadPlayers==numPlayers-1){
            //end Game
        }else{
            dropOuterBlocks();    
        }
    }
    public void dropOuterBlocks(){
        int x=0;
        int y=0;
        switch(deadPlayers){
            case 1:
                x=0;
                y=7;
                break;
            case 2:
                x=1;
                y=6;
                break; 
        }
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                if(i==x || i==y || j==x || j==y){
                    gameBoard[i,j]=.5;
                }
            }
        }
    }

    public void dropBlocks(string direction, (double x,double y) doubleplayerPos){
        (int x, int y) playerPos = (Convert.ToInt32(doubleplayerPos.x),Convert.ToInt32(doubleplayerPos.y));       
        switch(direction){
            case "East":
                if(playerPos.x!=7){
                    StartCoroutine(dropEast(playerPos));    
                }
                break;
            case "North":
                if(playerPos.y!=7){
                    StartCoroutine(dropNorth(playerPos));
                }
                break;
            case "South":
                if(playerPos.y!=0){
                    StartCoroutine(dropSouth(playerPos));
                }
                break;
            case "West":
                if(playerPos.x!=0){
                    StartCoroutine(dropWest(playerPos));
                }
                break;
    }




    IEnumerator dropNorth((int x, int y) playerPos){
        Boolean run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(.5f);
        }
        for(int i=playerPos.y+1;i<8;i++){
            if(gameBoard[playerPos.x,i]==0){
                gameBoard[playerPos.x,i]=1;
                yield return new WaitForSeconds(.1f);
            }                        
        }
    }
    IEnumerator dropSouth((int x, int y) playerPos){
        Boolean run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(.5f);
        }        
        for(int i=playerPos.y-1;i>-1;i--){
            if(gameBoard[playerPos.x,i]==0){
                gameBoard[playerPos.x,i]=1;
                yield return new WaitForSeconds(.1f);
            }      
        }
    }
    IEnumerator dropEast((int x, int y) playerPos){
        Boolean run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(.5f);
        }        
        for(int i=playerPos.x+1;i<8;i++){
            if(gameBoard[i,playerPos.y]==0){
                gameBoard[i,playerPos.y]=1;
                yield return new WaitForSeconds(.1f);
            }
        }   
    }
    IEnumerator dropWest((int x, int y) playerPos){
        Boolean run=false;
        if(run==false){
            run=true;
            yield return new WaitForSeconds(.5f);
        }        
        for(int i=playerPos.x-1;i>-1;i--){
            if(gameBoard[i,playerPos.y]==0){
                gameBoard[i,playerPos.y]=1;
                yield return new WaitForSeconds(.1f);
            }
        }
    }        
    }
}
