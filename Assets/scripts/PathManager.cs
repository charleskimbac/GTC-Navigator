using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {
    private LineRenderer lr;
    private List<Vector3> points = new List<Vector3>();
    private float z = 0;

    //


    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    public void addNodeLocation(Node a) {
        for (int i = 0; i < a.getXCoords().Count; i++) {
            points.Add(new Vector3(a.getXCoords()[i], a.getYCoords()[i], z));
        }
    }

    public void addNodeLocation(Vector3 coord) {
        points.Add(coord);
    }

    public void addNodeLocation(Node a, string direction) {
        Debug.Log("special");
        if (direction == "right") {
            points.Add(new Vector3(3.94f, -2.5f, z));
            points.Add(new Vector3(a.getXCoords()[0], a.getYCoords()[0], z));
            points.Add(new Vector3(5, -3.55f, z));
        }
        else if (direction == "left"){
            points.Add(new Vector3(5, -3.55f, z));
            points.Add(new Vector3(a.getXCoords()[0], a.getYCoords()[0], z));
            points.Add(new Vector3(3.94f, -2.5f, z));
        }
    }

    public void generatePath() {
        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());
    }

    public void resetPath() {
        points = new List<Vector3>();
    }
}