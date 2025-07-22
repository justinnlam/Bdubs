using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using ParrelSync;
#endif

public class JoinScreenManager : MonoBehaviour{

    public GameObject localLogic;
    public GameObject onlineLogic;
    
    public GameObject joinSlotPrefab;
    public Transform[] joinPanels;
    public GameObject startText;
    public Sprite[] crabImages; 
    
    //creates a user slot with the crabpic once a user joins so user can view
    public bool UseTestVar; 
    public bool TestVarIsLocal=false;

    void Awake() {
        if (UseTestVar) {
            if (TestVarIsLocal) {
                StaticGameModeManager.SetLocalMode();
            } else if(ClonesManager.IsClone()){
                StaticGameModeManager.SetOnlineMode(ServerType.Client);
            } else {
                StaticGameModeManager.SetOnlineMode(ServerType.Host);
            }
        }
    }

    void Start() {
        // StaticPlayerManager.ClearPlayers();
        localLogic.SetActive(StaticGameModeManager.IsLocal());
        onlineLogic.SetActive(StaticGameModeManager.IsOnline());
    }

    public void SyncJoinSlots(List<UIPlayerInfo> playerList){
        // Clear all join panels
        foreach (Transform panel in joinPanels){
            foreach (Transform child in panel){
                Destroy(child.gameObject);
            }
        }

        // Add join slot for each player using their playerIndex
        foreach (var player in playerList){
                if (player.playerIndex < 0 || player.playerIndex >= joinPanels.Length){
                    Debug.LogWarning($"Player index {player.playerIndex} out of range!");
                    continue;
                }

                Transform panel = joinPanels[player.playerIndex];
                GameObject joinSlotCrabImage = Instantiate(joinSlotPrefab, panel, false);

                // Set crab sprite
                Image image = joinSlotCrabImage.GetComponent<Image>();
                if (image != null && player.playerIndex < crabImages.Length){
                    image.sprite = crabImages[player.playerIndex];
                }

            // Enable start button if enough players
            if (playerList.Count >= 2 && !startText.activeSelf){
                startText.SetActive(true);
            }
        }
    }
}