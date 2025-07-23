using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Prediction;
using FishNet.Transporting;
using FishNet.Connection;
using FishNet;
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

    public override void OnStartServer(){
        base.OnStartServer();
        InstanceFinder.ServerManager.OnRemoteConnectionState += HandleRemoteConnectionState;
    }

    public override void OnStopServer(){
    base.OnStopServer();
    InstanceFinder.ServerManager.OnRemoteConnectionState -= HandleRemoteConnectionState;
    }

    private void HandleRemoteConnectionState(NetworkConnection conn, RemoteConnectionStateArgs  args){
        if (args.ConnectionState == RemoteConnectionState.Stopped){
            int connectionId = (int)conn.ClientId;

            playerList.RemoveAll(p => p.connectionId == connectionId);
            StaticPlayerManager.Remove(connectionId);
            UpdateClientsOnPlayerList(playerList);
        }
    }

    [Server]
    public void RegisterClientJoinToServer(int connectionId){
        UIPlayerInfo data = new UIPlayerInfo {
            connectionId = connectionId,
            playerIndex = playerList.Count,
        };
        playerList.Add(data);
        StaticPlayerManager.Create(connectionId);
        UpdateClientsOnPlayerList(playerList);
    }

    [ObserversRpc]
    private void UpdateClientsOnPlayerList(List<UIPlayerInfo> playerList){
        joinScreenManager.SyncJoinSlots(playerList);
    }

    [ServerRpc(RequireOwnership = false)]
    public void RequestStartGame(NetworkConnection conn = null){
            StaticSceneManager.LoadScene("BlockFall");
    }

}
