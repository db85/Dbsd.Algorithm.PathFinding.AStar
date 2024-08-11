using Dbsd.Algorithm.PathFinding.AStar;
using System.Numerics;

var pathFindingJob = new SimpleAStartJobImpl();
var pathFinding = new AStartPathfinding(pathFindingJob);
var jobInfo = new SimpleJobInfo(startPosition: Vector3.Zero, targetPosition: new Vector3(10f, 0, 10));

var result = pathFinding.FindPath(jobInfo, new CancellationToken());

if (result == null || result.Result == null)
    Console.WriteLine("No result found");
else
{
    Console.WriteLine($"Path found in {result.Iterations} iterations");
    var nodes = AStartPathfinding.GetPath<SimpleAStarNode>(result.Result);

    for (int i = 0; i < nodes.Count; i++)
        Console.WriteLine($"[{i}]: {nodes[i].Position.X}/{nodes[i].Position.Z}");
}

Console.ReadLine();