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
        PlayerInfo myInfo = PlayerSession.Players.Find(p => p.onlineNetworkConnectionId == (int) base.OwnerId);
        if (myInfo != null && myInfo.isFirstPlayer()){
            var NetworkJoinStateManager = FindObjectOfType<NetworkJoinStateManager>();
            NetworkJoinStateManager.RequestStartGame();
        }
    }
}
