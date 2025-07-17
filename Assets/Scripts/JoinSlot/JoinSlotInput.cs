using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JoinSlotInput : MonoBehaviour{

    void Start(){
        Debug.Log("JoinSlotInput Start");
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