using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {
    Local,
    Online
}

public enum ServerType{
    None,
    Host,
    Client,
    Server
}

public class StaticGameModeManager : MonoBehaviour {
    public static GameMode SelectedMode { get; private set; }
    public static ServerType OnlineRole { get; private set; }

    public static void SetLocalMode() {
        SelectedMode = GameMode.Local;
        OnlineRole = ServerType.None;
    }

    public static void SetOnlineMode(ServerType serverType) {
        SelectedMode = GameMode.Online;
        OnlineRole = serverType;
    }

    public static bool IsOnline() => SelectedMode == GameMode.Online;
    public static bool IsLocal() => SelectedMode == GameMode.Local;
    public static bool IsHost() => OnlineRole == ServerType.Host;
    public static bool IsClient() => OnlineRole == ServerType.Client;
    public static bool IsServer() => OnlineRole == ServerType.Server;

}