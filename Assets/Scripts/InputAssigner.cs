using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssigner : MonoBehaviour
{
    public PlayerInput player1; // Assign Player 1 (keyboard) object in Inspector
    public PlayerInput player2; // Assign Player 2 (gamepad) object in Inspector

    void Start()
    {
        // Assign keyboard to Player 1
        if (player1 != null && Keyboard.current != null)
        {
            player1.SwitchCurrentControlScheme("Keyboard", Keyboard.current);
            Debug.Log("Assigned Keyboard to Player 1");
        }

        // Assign gamepad to Player 2 (first detected gamepad)
        if (player2 != null && Gamepad.all.Count > 0)
        {
            player2.SwitchCurrentControlScheme("Gamepad", Gamepad.all[0]);
            Debug.Log("Assigned Gamepad to Player 2");
        }
    }
}