using Dbsd.Algorithm.PathFinding.AStar;
using System.Numerics;

public class SimpleAStarNode(string id, SimpleAStarNode? parent, Vector3 position, float estimatedCosts, float nodeCosts) : IAStarNode
{
    IAStarNode? IAStarNode.Parent => Parent;

    public SimpleAStarNode? Parent { get; set; } = parent;
    public string Id { get; } = id;
    public Vector3 Position { get; } = position;
    public float EstimatedCosts { get; } = estimatedCosts;
    public float NodeCosts { get; } = nodeCosts;
    public float TotalCosts { get; } = estimatedCosts + nodeCosts;

    public override string ToString() => $"Id: {Id}, TotalCosts: {TotalCosts}";
}

