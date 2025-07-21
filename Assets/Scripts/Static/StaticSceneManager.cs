using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using FishNet;
using FishNet.Managing.Scened;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

public static class StaticSceneManager{
    
    public static string GetCurrentScene(){
        return SceneManager.GetActiveScene().name;
    }
    
    public static void LoadScene(string sceneName){
        if(StaticGameModeManager.IsLocal()){
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }else{
            SceneLoadData sld = new SceneLoadData(sceneName);
            InstanceFinder.SceneManager.LoadGlobalScenes(sld);
            UnloadScene(GetCurrentScene());
        }

    }

    public static void UnloadScene(string sceneName){
        if(StaticGameModeManager.IsLocal()){
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }else{
            SceneUnloadData sld = new SceneUnloadData(sceneName);
            InstanceFinder.SceneManager.UnloadGlobalScenes(sld);
        }
    }

}
