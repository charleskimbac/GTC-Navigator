using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLocation : MonoBehaviour {
    public Transform current;

    float min = 30f;
    float max = 70f;
    float offset = 4f;
    private bool increasing = true;

    Vector3 maxScale;
    Vector3 minScale;

    int speed = 2;

    private void Start() {
        maxScale = new Vector3(max, max, max);
        minScale = new Vector3(min, min, min);
    }

    private void Update() {
        if (increasing) {
            current.localScale = Vector3.Lerp(current.localScale, maxScale, Time.deltaTime);
            if (current.localScale.x > maxScale.x - offset) {
                increasing = false;
            }
        }
        else {
            current.localScale = Vector3.Lerp(current.localScale, minScale, Time.deltaTime);
            if (current.localScale.x < minScale.x + offset) {
                increasing = true;
            }
        }
    }
}
