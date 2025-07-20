using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Transporting;
using FishNet.Managing;
using FishNet.Managing.Server;
using FishNet.Managing.Client;
using FishNet.Connection;


public class OnlineJoinHandler : MonoBehaviour {
    private JoinScreenManager manager;
    public GameObject networkManager;
    public GameObject networkJoinStateManager;
    
    void Start() {
        networkManager.SetActive(true);
        networkJoinStateManager.SetActive(true);
        Debug.Log("OnlineRole: "+StaticGameModeManager.OnlineRole);
        if (StaticGameModeManager.IsHost()) {
            Debug.Log("Host Started");
            InstanceFinder.ServerManager.StartConnection();
            InstanceFinder.ClientManager.StartConnection();
        } else if (StaticGameModeManager.IsServer()) {
            Debug.Log("Server Started");
            InstanceFinder.ServerManager.StartConnection();
        } else if (StaticGameModeManager.IsClient()) {
            Debug.Log("Client Started");
            InstanceFinder.ClientManager.StartConnection();
        } else{
            Debug.Log("Nothing Started?");
        }
    }

}