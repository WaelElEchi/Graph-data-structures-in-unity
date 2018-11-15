using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    public MapData mapData;
    public Graph graph;
    public Pathfinder pathfinder;

    public int startx = 0;
    public int starty = 0;
    public int goalx = 1;
    public int goaly = 1;

    private void Start()
    {
        if (mapData!=null&&graph!=null)
        {
            int[,] mapInstance = mapData.MakeMap();
            graph.Init(mapInstance);

            GraphView graphView = graph.gameObject.GetComponent<GraphView>();

            if (graphView!=null)
            {
                graphView.Init(graph);
            }

            Node startNode = graph.nodes[startx, starty];
            Node goalNode = graph.nodes[goalx, goaly];
            pathfinder.Init(graph, graphView, startNode, goalNode);
        }
    }
}