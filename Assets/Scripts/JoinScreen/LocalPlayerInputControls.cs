using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LocalPlayerInputControls : MonoBehaviour {
    public void OnStartGame(){
        SceneManager.LoadScene("BlockFall");
    }
}