using Dbsd.Algorithm.PathFinding.AStar;
using System.Numerics;

public class SimpleAStartJobImpl : IAStarJobImpl
{
    public int MaximumIteration => 500;

    public bool HasTargetReached(AStarJobInfo jobInfo, IAStarNode node)
    {
        var simpleJobInfo = (SimpleJobInfo)jobInfo;
        var simpleNode = (SimpleAStarNode)node;

        return simpleJobInfo.TargetPosition == simpleNode.Position;
    }

    public List<IAStarNode> Inflate(AStarJobInfo jobInfo, IAStarNode? parent)
    {
        var simpleJobInfo = (SimpleJobInfo)jobInfo;
        var simpleNodeParent = parent as SimpleAStarNode;

        if (simpleNodeParent == null)
            return [CreateNode(simpleJobInfo, null, simpleJobInfo.StartPosition)];

        return [
            CreateNode(simpleJobInfo, simpleNodeParent, simpleNodeParent.Position + new Vector3(-1, 0, 0)),
            CreateNode(simpleJobInfo, simpleNodeParent, simpleNodeParent.Position + new Vector3(1, 0, 0)),
            CreateNode(simpleJobInfo, simpleNodeParent, simpleNodeParent.Position + new Vector3(0, 0, -1)),
            CreateNode(simpleJobInfo, simpleNodeParent, simpleNodeParent.Position + new Vector3(0, 0, 1))
            ];
    }
    private static SimpleAStarNode CreateNode(SimpleJobInfo simpleJobInfo, SimpleAStarNode? parent, Vector3 position)
    {
        var estimatedCosts = Math.Abs(Vector3.Distance(position, simpleJobInfo.TargetPosition));

        return new SimpleAStarNode(id: $"{position.X} / {position.Y} / {position.Z}", parent, position: position, estimatedCosts: estimatedCosts, nodeCosts: 1);
    }
}

