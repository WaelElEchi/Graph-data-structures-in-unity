using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    open = 0,
    blocked = 1
}

public class Node
{
    public NodeType nodeType = NodeType.open;

    public int xIndex = -1;
    public int yIndex = -1;

    public Vector3 position;

    public List<Node> neighbors = new List<Node>();

    public Node previous = null;

    public Node(int xIndex, int yIndex, NodeType nodeType)
    {
        this.xIndex=xIndex;
        this.yIndex=yIndex;
        this.nodeType=nodeType;
    }

    public void Reset()
    {
        previous=null;
    }
}