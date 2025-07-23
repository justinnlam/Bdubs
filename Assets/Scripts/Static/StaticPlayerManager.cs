using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo {
    //both
    public int playerIndex;//player 1 vs 2\
    //used locally
    public PlayerInput localPlayerInput;//identifies the local player
    public InputDevice device;//gamepad vs keyboard
    //used online
    public int onlineNetworkConnectionId=-1;//identifies the online player

    public bool isFirstPlayer(){
        return playerIndex==0;
    }
}

[System.Serializable]
public struct UIPlayerInfo {
    public int playerIndex;
    public int connectionId;
}

public static class PlayerSession {
    public static List<PlayerInfo> Players = new List<PlayerInfo>();
}

public static class StaticPlayerManager {

    public static PlayerInfo Create(PlayerInput input) {
        var info = new PlayerInfo {
            device = input.devices.Count > 0 ? input.devices[0] : null,
            localPlayerInput = input,
            playerIndex = PlayerSession.Players.Count
        };
        PlayerSession.Players.Add(info);
        return info;
    }

    public static PlayerInfo Create(int connectionId) {
        var info = new PlayerInfo {
            onlineNetworkConnectionId = connectionId,
            playerIndex = PlayerSession.Players.Count
        };
        PlayerSession.Players.Add(info);
        return info;
    }

    public static void Remove(int connectionId) {
        PlayerSession.Players.RemoveAll(p => p.onlineNetworkConnectionId == connectionId);
    }

    public static PlayerInfo getPlayerInfo(PlayerInput playerInput){
        return PlayerSession.Players.Find(p => p.localPlayerInput == playerInput);
    }

    public static PlayerInfo getPlayerInfo(int connectionId){
        return PlayerSession.Players.Find(p => p.onlineNetworkConnectionId == connectionId);
    }

    public static void ClearPlayers() {
        PlayerSession.Players.Clear();
    }

    public static List<UIPlayerInfo> GetAllUIInfo(){
        List<UIPlayerInfo> uiList = new();
        foreach (var info in PlayerSession.Players){
            uiList.Add(new UIPlayerInfo {
                playerIndex = info.playerIndex,
                connectionId = info.onlineNetworkConnectionId
            });
        }
        return uiList;
    }
}
