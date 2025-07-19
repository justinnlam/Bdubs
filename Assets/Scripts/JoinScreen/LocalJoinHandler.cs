using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LocalJoinHandler : MonoBehaviour {
    private JoinScreenManager manager;

    void Start() {
        manager = FindObjectOfType<JoinScreenManager>();
    }

    public void OnPlayerJoined(PlayerInput playerInput) {
        manager.AddJoinSlot();
        StaticPlayerManager.Create(playerInput);
    }

}