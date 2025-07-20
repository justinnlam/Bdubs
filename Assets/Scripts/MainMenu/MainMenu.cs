using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayModePanel;
    public GameObject MainMenuFirstButton;
    public GameObject PlayModeFirstButton;

    public void Play(){
        MainMenuPanel.SetActive(false);
        PlayModePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null); 
        EventSystem.current.SetSelectedGameObject(PlayModeFirstButton);
    }

    public void Settings(){

    }
    
    public void Quit(){
        Application.Quit();
    }

    public void Local(){
        StaticGameModeManager.SetLocalMode();
        SceneManager.LoadScene("JoinScreen");
    }
    public void Online(){
        StaticGameModeManager.SetOnlineMode(ServerType.Host);
        SceneManager.LoadScene("JoinScreen");
    }
    public void Back(){
        MainMenuPanel.SetActive(true);
        PlayModePanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null); 
        EventSystem.current.SetSelectedGameObject(MainMenuFirstButton);
    }
}
