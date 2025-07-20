using FishNet.Object;
using UnityEngine;
// A script that lives on the player prefab that gets spawned by FishNet’s NetworkManager.
public class NetworkPlayerJoin : NetworkBehaviour {
    public override void OnStartClient(){
        base.OnStartClient();
        if (IsOwner){
            CmdNotifyJoin();
        }
    }

    [ServerRpc]
    private void CmdNotifyJoin(){
        NetworkJoinStateManager mgr = FindObjectOfType<NetworkJoinStateManager>();
        if (mgr != null){
            mgr.RegisterJoin((int) base.OwnerId);
        }
    }

}
