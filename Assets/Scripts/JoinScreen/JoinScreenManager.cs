using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    void Start() {
        Debug.Log("Is Local?" + StaticGameModeManager.IsLocal());
        StaticPlayerManager.ClearPlayers();
        localLogic.SetActive(StaticGameModeManager.IsLocal());
        onlineLogic.SetActive(StaticGameModeManager.IsOnline());
    }

  public void AddJoinSlot() {
        if (currentJoinIndex >= joinPanels.Length) return;

        if (currentJoinIndex >= 1 && !startText.activeSelf)
        {
            startText.SetActive(true);
        }
        Transform panel = joinPanels[currentJoinIndex];
        GameObject joinSlotCrabImage = Instantiate(joinSlotPrefab, panel, false);

        // Set crab sprite
        Image image = joinSlotCrabImage.GetComponent<Image>();
        if (image != null && currentJoinIndex < crabImages.Length) {
            image.sprite = crabImages[currentJoinIndex];
        }

        RectTransform rt = joinSlotCrabImage.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        currentJoinIndex++;
    }
}