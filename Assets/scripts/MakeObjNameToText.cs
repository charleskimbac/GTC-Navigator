using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class MakeObjNameToText : MonoBehaviour {

    private void Awake() {
        /*
        int ind1 = gameObject.name.IndexOf(' ', 0);
        int ind2 = gameObject.name.IndexOf(' ', ind1);
        string a = gameObject.name.Substring(0, ind1 + 1);
        string b = gameObject.name.Substring(ind2);
        gameObject.name = b + " " + a;
        */
        gameObject.GetComponent<TMP_Text>().text = transform.parent.gameObject.transform.parent.gameObject.name;
        
        //gameObject.name = "Hall " + gameObject.name;
    }
}