namespace Dbsd.Algorithm.PathFinding.AStar
{
    public interface IAStarNode
    {
        string Id { get; }
        IAStarNode? Parent { get; }
        float TotalCosts { get; }
    }
}
