// GameInitializer.cs
using UnityEngine;
using FishNet;
using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine.InputSystem;
public enum GameMode {
    Local,
    Online
}

public class GameInitializer : MonoBehaviour
{
    public GameMode mode;
    public GameObject localPlayerPrefab;
    public Transform[] localSpawnPoints;
    public GameObject networkPlayerPrefab;
    public Transform networkSpawnPoint;
    [SerializeField] private InputActionAsset inputActions; 

    private void Start()
    {
        if (mode == GameMode.Local)
        {
            StartLocalMode();
        }
        else if (mode == GameMode.Online)
        {
            StartOnlineMode();
        }
    }

    private void StartLocalMode()
    {
        var manager = FindObjectOfType<UnityEngine.InputSystem.PlayerInputManager>();
        if (manager != null)
        {
            manager.enabled = true;
            manager.EnableJoining();
        }
    }

    private void StartOnlineMode()
    {
        // Disable PlayerInputManager if present
        var manager = FindObjectOfType<UnityEngine.InputSystem.PlayerInputManager>();
        if (manager != null)
            manager.enabled = false;

        // Start FishNet client/server as needed
        InstanceFinder.ServerManager.StartConnection();
        InstanceFinder.ClientManager.StartConnection();

        // Optional: listen for OnClientConnected event to spawn
    }
}
