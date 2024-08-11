namespace Dbsd.Algorithm.PathFinding.AStar
{
    public class DebugInformation(IAStarNode current, List<IAStarNode> neighbours)
    {
        public IAStarNode Current { get; } = current;
        public List<IAStarNode> Neighbours { get; } = neighbours;
    }
}
