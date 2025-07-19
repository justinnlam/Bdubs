using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo {
    public InputDevice device;
    public int playerIndex;
    public PlayerInput localPlayerInput;
    public int onlineNetworkConnectionId;
}

public static class PlayerSession {
    public static List<PlayerInfo> Players = new List<PlayerInfo>();
}

public static class StaticPlayerManager {
    public static PlayerInfo Create(PlayerInput input) {
        var info = new PlayerInfo {
            device = input.devices.Count > 0 ? input.devices[0] : null,
            localPlayerInput = input,
            playerIndex = input.playerIndex
        };
        PlayerSession.Players.Add(info);
        return info;
    }

    public static PlayerInfo Create(int connectionId) {
        var info = new PlayerInfo {
            onlineNetworkConnectionId = connectionId,
            playerIndex = connectionId
        };
        PlayerSession.Players.Add(info);
        return info;
    }
}
