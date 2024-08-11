using Dbsd.Algorithm.PathFinding.AStar;
using System.Numerics;

public class SimpleJobInfo(Vector3 startPosition, Vector3 targetPosition) : AStarJobInfo
{
    public Vector3 StartPosition { get; } = startPosition;
    public Vector3 TargetPosition { get; } = targetPosition;
}

