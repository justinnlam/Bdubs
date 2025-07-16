using UnityEngine;
using UnityEngine.InputSystem;

public class JoinSlotManager : MonoBehaviour
{
    public GameObject joinSlotPrefab;
    public Transform[] joinPanels;

    private int currentJoinIndex = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (currentJoinIndex >= joinPanels.Length)
        {
            Debug.LogWarning("Max players reached");
            return;
        }

        Transform panel = joinPanels[currentJoinIndex];
        GameObject joinSlotUI = Instantiate(joinSlotPrefab, panel);

        RectTransform rt = joinSlotUI.GetComponent<RectTransform>();
        rt.anchorMin = Vector2.zero;
        rt.anchorMax = Vector2.one;
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        currentJoinIndex++;
    }
}