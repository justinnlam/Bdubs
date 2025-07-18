using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinScreenManager : MonoBehaviour
{
    public GameObject joinSlotPrefab;
    public Transform[] joinPanels;
    public GameObject startText;
    public Sprite[] crabImages; 

    private int currentJoinIndex = 0;
    //clears all player sessions when starting this screen.
    //creates a user slot with the crabpic once a user joins so user can view 
    void Start(){
        PlayerSession.Players.Clear();
    }

    public void OnPlayerJoined(PlayerInput playerInput){
        if (currentJoinIndex >= joinPanels.Length){
            Debug.LogWarning("Max players reached");
            return;
        }
        if (currentJoinIndex >= 1 && !startText.activeSelf)
        {
            startText.SetActive(true);
        }
        Transform panel = joinPanels[currentJoinIndex];
        GameObject joinSlotUI = Instantiate(joinSlotPrefab, panel, false);

        // Set crab sprite
        Image image = joinSlotUI.GetComponent<Image>();
        if (image != null && currentJoinIndex < crabImages.Length) {
            image.sprite = crabImages[currentJoinIndex];
        }

        RectTransform rt = joinSlotUI.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        currentJoinIndex++;
    }
}