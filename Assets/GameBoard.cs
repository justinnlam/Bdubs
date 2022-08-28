using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBoard : MonoBehaviour{
    public int[,] gameBoard = new int[8,8];
    public int reappearTime=4000;
    public int dropTime=400;
    Material EvenColor;
    Material OddColor;
    // Start is called before the first frame update
    public GameBoard(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                gameBoard[i,j]=0;
            }
        }        
    }
    public void recalculateCubes(Material dw,Material even,Material odd){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                GameObject cube = GameObject.Find("Cube"+i+j);                   
                if(gameBoard[i,j]==reappearTime){
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
                else if(gameBoard[i,j]==dropTime){
                    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                    gameBoard[i,j]+=1;
                }
                else if(gameBoard[i,j]>0){
                    gameBoard[i,j]+=1;
                    cube.GetComponent<MeshRenderer>().material = dw;                    
                }
            }
        }
    }
    public void dropBlocks(string direction, (double x,double y) doubleplayerPos){
        (int x, int y) playerPos;
        playerPos = (Convert.ToInt32(doubleplayerPos.x),Convert.ToInt32(doubleplayerPos.y));
        Debug.Log("X: "+doubleplayerPos.x+" Y: "+doubleplayerPos.y);              
        Debug.Log("X: "+playerPos.x+" Y: "+playerPos.y);              
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
        for(int i=playerPos.y+1;i<8;i++){
            if(gameBoard[playerPos.x,i]==0){
                gameBoard[playerPos.x,i]=1;
                yield return new WaitForSeconds(.1f);
            }                        
        }
    }
    IEnumerator dropSouth((int x, int y) playerPos){
        for(int i=playerPos.y-1;i>-1;i--){
            if(gameBoard[playerPos.x,i]==0){
                gameBoard[playerPos.x,i]=1;
                yield return new WaitForSeconds(.1f);
            }      
        }
    }
    IEnumerator dropEast((int x, int y) playerPos){
        for(int i=playerPos.x+1;i<8;i++){
            if(gameBoard[i,playerPos.y]==0){
                gameBoard[i,playerPos.y]=1;
                yield return new WaitForSeconds(.1f);
            }
        }   
    }
    IEnumerator dropWest((int x, int y) playerPos){
        for(int i=playerPos.x-1;i>-1;i--){
            if(gameBoard[i,playerPos.y]==0){
                gameBoard[i,playerPos.y]=1;
                yield return new WaitForSeconds(.1f);
            }
        }
    }        
    }
}
