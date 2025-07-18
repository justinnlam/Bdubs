using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//creates a player session when a player joins. sits in player input on the preFab
public class JoinSlotInput : MonoBehaviour{

    void Start(){
         var input = GetComponent<PlayerInput>();
                var info = new PlayerInfo {
            device = input.devices[0],
            playerInput = input,
            playerIndex = input.playerIndex
        };
        PlayerSession.Players.Add(info);
    }

    public void OnStartGame(){
        SceneManager.LoadScene("BlockFall");
    }

}