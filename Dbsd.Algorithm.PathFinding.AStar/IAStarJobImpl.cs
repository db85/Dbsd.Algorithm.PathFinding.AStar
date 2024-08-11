namespace Dbsd.Algorithm.PathFinding.AStar
{
    public interface IAStarJobImpl
    {
        int MaximumIteration { get; }
        public List<IAStarNode> Inflate(AStarJobInfo jobInfo, IAStarNode? parent);
        bool HasTargetReached(AStarJobInfo jobInfo, IAStarNode node);
    }
}
