using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInfo {
    public InputDevice device;
    public PlayerInput playerInput;
    public int playerIndex;
}

public static class PlayerSession {
    public static List<PlayerInfo> Players = new List<PlayerInfo>();
}
