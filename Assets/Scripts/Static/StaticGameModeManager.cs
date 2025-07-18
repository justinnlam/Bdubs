using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGameModeManager : MonoBehaviour
{
    public static GameMode SelectedMode { get; private set; }

    public void SetLocalMode(){
        SelectedMode = GameMode.Local;
    }

    public void SetOnlineMode(){
        SelectedMode = GameMode.Online;
    }
}
