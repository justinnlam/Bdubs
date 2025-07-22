using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Prediction;
using FishNet.Transporting;
using FishNet.Connection;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

/*
A singleton-style network-aware manager on the server that keeps track of 
how many players have joined and tells all clients to update their UI.
*/
public class NetworkJoinStateManager : NetworkBehaviour {
    public JoinScreenManager joinScreenManager;
    private List<UIPlayerInfo> playerList = new();
    
    //used as backup, can ignore
    public override void OnStartClient(){
        base.OnStartClient();
        if (joinScreenManager == null){
            joinScreenManager = FindObjectOfType<JoinScreenManager>();
            if (joinScreenManager == null){
                Debug.LogWarning("JoinScreenManager was not found on client.");
            }
        }
    }

    [Server]
    public void RegisterClientJoinToServer(int connectionId){
        UIPlayerInfo data = new UIPlayerInfo {
            connectionId = connectionId,
            playerIndex = playerList.Count,
        };
        playerList.Add(data);
        UpdateClientsOnPlayerCount(playerList);
    }

    [ObserversRpc]
    private void UpdateClientsOnPlayerCount(List<UIPlayerInfo> playerList){
        joinScreenManager.SyncJoinSlots(playerList);
    }



    [ServerRpc(RequireOwnership = false)]
    public void RequestStartGame(NetworkConnection conn = null){
            StaticSceneManager.LoadScene("BlockFall");
    }

}
