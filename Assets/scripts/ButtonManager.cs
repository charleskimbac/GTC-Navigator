using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public GameObject mapObj;
    public TMP_Text mapBT;
    //BT = button text

    public GameObject creditsObj;

    public void map() {
        if (mapObj.active == true) {
            mapObj.SetActive(false);
            mapBT.text = "Open Map";
        }
        else {
            mapObj.SetActive(true);
            mapBT.text = "Close Map";
        }
    }

    public void test() {
        Debug.Log("pressed");
    }

    public void credits() {
        if (creditsObj.active == true) {
            creditsObj.SetActive(false);
        }
        else {
            creditsObj.SetActive(true);
        }
    }

    public void github() {
        Application.OpenURL("https://github.com/kculbreth36/School-Building-Map");
    }
}
