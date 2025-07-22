using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocalJoinHandler : MonoBehaviour {
    private JoinScreenManager manager;

    void Start() {
        manager = FindObjectOfType<JoinScreenManager>();
    }

    public void OnPlayerJoined(PlayerInput playerInput) {
        PlayerInfo playerInfo = StaticPlayerManager.Create(playerInput);
        List<UIPlayerInfo> playerList = StaticPlayerManager.GetAllUIInfo();
        manager.SyncJoinSlots(playerList);
    }

}