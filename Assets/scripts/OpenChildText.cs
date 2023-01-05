using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChildText : MonoBehaviour {
    public GameObject textObj;
    public static GameObject active;

    public void pressed() {
        if (textObj.active == true) {
            textObj.SetActive(false);
        }
        else {
            if (active != null) {
                active.SetActive(false);
            }
            textObj.SetActive(true);
            active = this.gameObject.transform.GetChild(0).gameObject;
        }
    }
}
