using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using FishNet;
using FishNet.Managing.Scened;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Object.Prediction;
using FishNet.Transporting;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
public class PlayerInputControls : MonoBehaviour {
    public void OnStartGame(){
        if (StaticGameModeManager.IsLocal()) {
            PlayerInfo myInfo = PlayerSession.Players.Find(p => p.localPlayerInput == GetComponent<PlayerInput>());
            if (myInfo.playerIndex == 0){
                StaticSceneManager.LoadScene("BlockFall");
            }
        } else {
            var NetworkJoinStateManager = FindObjectOfType<NetworkJoinStateManager>();
                NetworkJoinStateManager.RequestStartGame();
        }
    }

}