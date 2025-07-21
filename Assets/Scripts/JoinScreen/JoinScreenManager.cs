using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    
    private int currentJoinIndex = 0;
    //clears all player sessions when starting this screen.
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
        StaticPlayerManager.ClearPlayers();
        localLogic.SetActive(StaticGameModeManager.IsLocal());
        onlineLogic.SetActive(StaticGameModeManager.IsOnline());
    }

  public void AddJoinSlot() {
        Debug.Log("RunningAddJoinSlot");
        if (currentJoinIndex >= joinPanels.Length) return;

        if (currentJoinIndex >= 1 && !startText.activeSelf){
            startText.SetActive(true);
        }
        Transform panel = joinPanels[currentJoinIndex];
        GameObject joinSlotCrabImage = Instantiate(joinSlotPrefab, panel, false);

        // Set crab sprite
        Image image = joinSlotCrabImage.GetComponent<Image>();
        if (image != null && currentJoinIndex < crabImages.Length){
            image.sprite = crabImages[currentJoinIndex];
        }

        RectTransform rt = joinSlotCrabImage.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        currentJoinIndex++;
                Debug.Log("FinishJoinSlot");

    }

    
    //ONLINE
    public void SyncJoinSlots(int count){
    // Add missing slots
    while (currentJoinIndex < count){
        AddJoinSlot();
    }
    // Optionally: remove extra slots if count < currentJoinIndex
    // for visual correctness (like if a player leaves)
}
}