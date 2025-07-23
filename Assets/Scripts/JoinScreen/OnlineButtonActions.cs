using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Prediction;
using FishNet.Transporting;
public class OnlineButtonActions : NetworkBehaviour
{
    public void OnStartGame(){
        Debug.Log("Start Game Requested");
        PlayerInfo myInfo = StaticPlayerManager.getPlayerInfo((int) base.OwnerId);

        if (myInfo != null && myInfo.isFirstPlayer()){
            Debug.Log("Start Game Valid");

            var NetworkJoinStateManager = FindObjectOfType<NetworkJoinStateManager>();
            NetworkJoinStateManager.RequestStartGame();
        }
    }
}
