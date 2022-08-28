using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard{
    public int[,] gameBoard = new int[8,8];
    // Start is called before the first frame update
    public GameBoard(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                gameBoard[i,j]=0;
            }
        }        
    }
    public void recalculateCubes(){
        for(int i=0;i<8;i++){
            for(int j=0;j<8;j++){
                    GameObject cube = GameObject.Find("Cube"+i+j);                   
                if(gameBoard[i,j]==660){
                    UnityEngine.Object.Destroy(cube.GetComponent<Rigidbody>());
                    cube.transform.position=new Vector3(i,0,j);
                    gameBoard[i,j]=0;
                }
                else if(gameBoard[i,j]==60){
                    Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                    gameBoard[i,j]+=1;
                }
                else if(gameBoard[i,j]>0){
                    gameBoard[i,j]+=1;
                }
            }
        }
    }
    public void dropBlocks(string direction, (double x,double y) doubleplayerPos){
        (int x, int y) playerPos;
        playerPos = ((int)doubleplayerPos.x,(int) doubleplayerPos.y);

        switch(direction){
            case "East":
                if(playerPos.x!=7){
                    for(int i=playerPos.x+1;i<8;i++){
                        if(gameBoard[i,playerPos.y]==0){
                            gameBoard[i,playerPos.y]=1;
                        }
                    }       
                }
                break;
            case "North":
                if(playerPos.y!=7){
                    for(int i=playerPos.y+1;i<8;i++){
                        if(gameBoard[playerPos.x,i]==0){
                            gameBoard[playerPos.x,i]=1;
                        }                        
                    }
                }
                break;
            case "South":
                if(playerPos.y!=0){
                    for(int i=playerPos.y-1;i>-1;i--){
                        if(gameBoard[playerPos.x,i]==0){
                            gameBoard[playerPos.x,i]=1;
                        }      
                        Debug.Log("X: "+playerPos.x+" Y: "+i);              
                    }
                }
                break;
            case "West":
                if(playerPos.x!=0){
                    for(int i=playerPos.x-1;i>-1;i--){
                        if(gameBoard[i,playerPos.y]==0){
                            gameBoard[i,playerPos.y]=1;
                        }
                    }
                }
                break;
        }


    }
}
