using System;
using UnityEngine;
using FishNet;
using FishNet.Managing;
using FishNet.Transporting;

public enum ConnectionType
{
    Host,
    Client
}

public class ConnectionHandler : MonoBehaviour
{
    public ConnectionType connectionType;

    private void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;
    }

    private void OnClientConnectionState(ClientConnectionStateArgs args)
    {
        if (args.ConnectionState == LocalConnectionState.Stopping)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    private void Start()
    {
#if UNITY_EDITOR
        if (ParrelSync.ClonesManager.IsClone())
        {
            InstanceFinder.ClientManager.StartConnection();
        }
        else
        {
            if (connectionType == ConnectionType.Host)
            {
                InstanceFinder.ServerManager.StartConnection();
                InstanceFinder.ClientManager.StartConnection();
            }
            else
            {
                InstanceFinder.ClientManager.StartConnection();
            }
        }
#endif

#if DEDICATED_SERVER
        InstanceFinder.ServerManager.StartConnection();
#endif
    }
}
