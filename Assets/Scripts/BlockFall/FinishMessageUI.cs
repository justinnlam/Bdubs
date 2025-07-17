using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FinishMessageUI : MonoBehaviour {
    
    public TextMeshProUGUI text;

    void Start() {
    text.gameObject.SetActive(false);
    }
    public void ShowMessage(){
            Debug.Log("Set Active");

        text.gameObject.SetActive(true);
            Debug.Log("Set Active2");

    }


}
