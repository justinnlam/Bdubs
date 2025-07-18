using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameMode {
    Local,
    Online
}

public class StaticGameModeManager : MonoBehaviour
{
    public static GameMode SelectedMode { get; private set; }

    public static void SetLocalMode(){
        SelectedMode = GameMode.Local;
    }

    public static void SetOnlineMode(){
        SelectedMode = GameMode.Online;
    }
}
