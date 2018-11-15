using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private Node startNode;
    private Node goalNode;

    private Graph _graph;
    private GraphView _graphView;

    private Queue<Node> frontierNodes;
    private List<Node> exploredNodes;
    private List<Node> pathNodes;

    public Color startColor = Color.yellow;
    public Color goalColor = Color.cyan;

    public Color frontierColor = Color.magenta;
    public Color exploredColor = Color.grey;
    public Color pathColor = Color.red;

    public void Init(Graph graph, GraphView graphView, Node start, Node goal)
    {
        if (start==null||goal==null||graph==null||graphView==null)
        {
            Debug.LogWarning("Pathfinder info null (start goal graph pathview)");
            return;
        }

        if (start.nodeType==NodeType.blocked||goal.nodeType==NodeType.blocked)
        {
            Debug.LogWarning("start or node bloecked");
            return;
        }

        _graph=graph;
        _graphView=graphView;
        startNode=start;
        goalNode=goal;

        NodeView startNodeView = graphView.nodeViews[start.xIndex, start.yIndex];

        if (startNodeView!=null)
        {
            startNodeView.ColorNode(startColor);
        }

        NodeView goalNodeView = graphView.nodeViews[goal.xIndex, goal.yIndex];

        if (goalNodeView!=null)
        {
            goalNodeView.ColorNode(goalColor);
        }

        frontierNodes=new Queue<Node>();
        frontierNodes.Enqueue(start);

        exploredNodes=new List<Node>();
        pathNodes=new List<Node>();

        for (int x = 0; x<graph.width; x++)
        {
            for (int y = 0; y<graph.height; y++)
            {
                graph.nodes[x, y].Reset();
            }
        }
    }
}