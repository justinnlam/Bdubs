using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDManager : MonoBehaviour {
    public GameObject[] playerHUDs;
    public static HUDManager Instance { get; private set; }

    private void Awake(){
        Instance = this;
    }

    public void DisableUnusedHUDs(int totalPlayers){
        for (int i = totalPlayers; i < playerHUDs.Length; i++){
            playerHUDs[i].SetActive(false);
        }
    }

    public void UpdatePlayerLife(int playerIndex, int lives){
        if (playerIndex < playerHUDs.Length){
            var texts = playerHUDs[playerIndex].GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var text in texts){
                if (text.name.EndsWith("Count")){
                    text.text = $"x {lives}";
                    break;
                }
            }
        }
    }
}

