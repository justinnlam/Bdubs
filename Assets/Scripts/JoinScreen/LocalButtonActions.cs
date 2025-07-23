using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalButtonActions : MonoBehaviour
{
    public void OnStartGame(){
        PlayerInfo myInfo = StaticPlayerManager.getPlayerInfo(GetComponent<PlayerInput>());

        if (myInfo.isFirstPlayer()){
            StaticSceneManager.LoadScene("BlockFall");
        }
    }
}
