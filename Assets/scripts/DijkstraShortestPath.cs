using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//'priority queue -> List' implementation at bottom nvm

public class DijkstraShortestPath : ScriptableObject {
    //
    int index;
    List<Node> priorityQueue;
    public void computeShortestPaths(Node sourceNode) {
        //Debug.Log("start of cSP()");
        // sets the distance for the source node to zero instead of infinity, as is standard*
        sourceNode.setDistance(0);
        //Debug.Log("1");
        // creates a priority queue of the node typing
        priorityQueue = new List<Node>(); //================================PRIO QUEUE -> LIST
        // sets the node given in the method parameter as the node with the priority inside the queue, thereby giving order to it
        //=======implementing queue -> list algo
        //Debug.Log("2");
        
        priorityQueue.Add(sourceNode);

        // sets the source as visited already, to not have repeats
        sourceNode.setVisited(true);
        //Debug.Log("4");
        // while loop for when priority queue is not empty
        while (priorityQueue.Count > 0) {
            //Debug.Log("5");
            // declares actualNode as the node with priority in the queue, then removes it
            Node actualNode = priorityQueue[0];
            priorityQueue.RemoveAt(0);
            //Debug.Log("6");
            // for loop to go by each hall attached to the actualNode as the starting point
            foreach (Hall hall in actualNode.getAdjacentList()) {
                //Debug.Log("7");
                // declares n as the node that is the end point(DestinationNode) of the hall
                Node n = hall.getDestinationNode();
                //Debug.Log("7abc");
                // if statement for when the destination has not been visited
                if (!n.isVisited()) {
                    //Debug.Log("8");
                    // declares a new distance as the weight of the hall plus the nodes distance
                    int newDistance = actualNode.getDistance() + hall.getWeight();

                    // if statement for when the new distance is less that the destinations distance
                    if (newDistance < n.getDistance()) {
                        //Debug.Log("9");
                        // removes n from the queue
                        priorityQueue.Remove(n);
                        //Debug.Log("9abc");
                        // sets the distance on the n node to the newly found distance
                        n.setDistance(newDistance);
                        //Debug.Log("10");
                        // sets the predecessor for node n as the node being looked at
                        n.setPredecessor(actualNode);
                        //Debug.Log("11");
                        // adds n back to the priority queue
                        if (priorityQueue.Count == 0) {
                            priorityQueue.Add(n);
                        }
                        else if (priorityQueue.Count == 1) {
                            if (n.getDistance() > priorityQueue[0].getDistance()) {
                                priorityQueue.Add(n);
                            }
                            else {
                                priorityQueue.Insert(0, n);
                            }
                        }
                        else {
                            for (int i = 0; i < priorityQueue.Count; i++) {
                                if (n.getDistance() <= priorityQueue[i].getDistance()) {
                                    priorityQueue.Insert(i, n);
                                    break;
                                }
                                else if (i == priorityQueue.Count - 1) {
                                    priorityQueue.Add(n);
                                }
                            }
                        }
                    }
                }
            }

            // sets the value of the node as to visited
            //Debug.Log("13");
            actualNode.setVisited(true);
            //Debug.Log("14");
        }
    }

    // method to get the shortest path to a certain node from the start node
    public List<Node> getShortestPathTo(Node targetNode) {

        // creates list of nodes named path
        List<Node> path = new List<Node>();

        // for loop that backwards searches from the target, adding nodes, until it gets to the start
        for (Node node = targetNode; node != null; node = node.getPredecessor()) {
            path.Add(node);
        }

        // reverses the list so that it is start to end
        path.Reverse();
        return path;
    }
}