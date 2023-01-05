using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hall : ScriptableObject {
    // fields to set the length(Weight), starting position and end position of a hallway
    private int weight;
    private Node startNode;
    private Node destinationNode;

    // getters and setters
    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public Node getStartNode() {
        return startNode;
    }

    public void setStartNode(Node startNode) {
        this.startNode = startNode;
    }

    public Node getDestinationNode() {
        return destinationNode;
    }

    public void setDestinationNode(Node destinationNode) {
        this.destinationNode = destinationNode;
    }

    //constructor
    public static Hall createInstance(int weight, Node startNode, Node destinationNode) {
        Hall temp = ScriptableObject.CreateInstance<Hall>();
        temp.weight = weight;
        temp.startNode = startNode;
        temp.destinationNode = destinationNode;
        return temp;
    }
}
