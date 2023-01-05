using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour {
    // fields for a nodes name, list of hallways attached, whether it has been visited, the previous node and its distance
    public new string name;
    private List<Hall> adjacentList = new List<Hall>();
    private bool visited;
    private Node predecessor;
    private int distance = int.MaxValue;
    public List<float> xCoords = new List<float>();
    public List<float> yCoords = new List<float>();
    private char[] nums = new char[] {
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    void Start() {
        xCoords.Insert(xCoords.Count / 2, gameObject.GetComponent<RectTransform>().localPosition.x);
        yCoords.Insert(yCoords.Count / 2, gameObject.GetComponent<RectTransform>().localPosition.y);

        int beg;
        if (gameObject.name.IndexOf("Entrance") != -1) {
            beg = gameObject.name.IndexOf(' ', 9); //9 = after "Entrance "
        }
        else {
            beg = gameObject.name.IndexOf(' ', 5); //5 = after "Hall "
        }
        name = gameObject.name.Substring(0, beg);
    }

    public List<float> getXCoords() { //list instead of single value to account for multiple coords being needed (entrance1)
        return xCoords;
    }

    public List<float> getYCoords() { //list instead of single value to account for multiple coords being needed (entrance1)
        return yCoords;
    }

    public void addCoord(float x, float y) {
        xCoords.Add(x);
        yCoords.Add(y);
    }


    // method to add a hallway to the node
    public void addNeighbour(Hall hall) {
        this.adjacentList.Add(hall);
    }

    // getters and setters
    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public List<Hall> getAdjacentList() {
        return adjacentList;
    }

    public void setAdjacentList(List<Hall> adjacentList) {
        this.adjacentList = adjacentList;
    }

    public bool isVisited() {
        return visited;
    }

    public void setVisited(bool visited) {
        this.visited = visited;
    }

    public Node getPredecessor() {
        return predecessor;
    }

    public void setPredecessor(Node predecessor) {
        this.predecessor = predecessor;
    }

    public int getDistance() {
        return distance;
    }

    public void setDistance(int distance) {
        this.distance = distance;
    }

    // Override - method to get the name of the string
    override
    public string ToString() {
        return this.name;
    }

    /*constructor
    public static Node createInstance(string name) {
        Node temp = ScriptableObject.CreateInstance<Node>();
        temp.name = name;
        return temp;
    }

    public static Node createInstance(string name, float x, float y) {
        Node temp = ScriptableObject.CreateInstance<Node>();
        temp.name = name;
        return temp;
    }
    */
}