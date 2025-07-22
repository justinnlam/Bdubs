using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalButtonActions : MonoBehaviour
{
    public void OnStartGame(){
        PlayerInfo myInfo = PlayerSession.Players.Find(p => p.localPlayerInput == GetComponent<PlayerInput>());
        if (myInfo.isFirstPlayer()){
            StaticSceneManager.LoadScene("BlockFall");
        }
    }
}
