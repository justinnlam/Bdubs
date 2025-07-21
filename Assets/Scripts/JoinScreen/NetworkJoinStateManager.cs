using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Prediction;
using FishNet.Transporting;
using FishNet.Connection;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
A singleton-style network-aware manager on the server that keeps track of 
how many players have joined and tells all clients to update their UI.
*/
public class NetworkJoinStateManager : NetworkBehaviour {
    private int playerCount = 0;
    public JoinScreenManager joinScreenManager;

public override void OnStartClient(){
    base.OnStartClient();

    if (joinScreenManager == null){
        joinScreenManager = FindObjectOfType<JoinScreenManager>();
    }
}

    public override void OnStartServer(){
        base.OnStartServer();
        playerCount = 0;

        if (joinScreenManager == null){
            joinScreenManager = FindObjectOfType<JoinScreenManager>();
        }
    }

    [Server]
    public void RegisterJoin(int connectionId){
        playerCount+=1;
        StaticPlayerManager.Create(connectionId);
        if (joinScreenManager != null) {
            RpcUpdateJoinUI(playerCount);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void RequestStartGame(NetworkConnection conn = null){
            StaticSceneManager.LoadScene("BlockFall");
    }

    [ObserversRpc]
    private void RpcUpdateJoinUI(int count){
        Debug.Log("[JoinStateManager] Received join count = " + count);
        joinScreenManager.SyncJoinSlots(count);
    }
}
