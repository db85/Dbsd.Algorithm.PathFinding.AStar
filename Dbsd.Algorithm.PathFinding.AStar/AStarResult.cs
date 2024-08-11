namespace Dbsd.Algorithm.PathFinding.AStar
{
    public class AStarResult(AStarJobInfo jobInfo, IAStarNode? result, int iterations, List<DebugInformation>? debugInformations = null)
    {
        public IAStarNode? Result { get; } = result;
        public int Iterations { get; } = iterations;
        public AStarJobInfo JobInfo { get; } = jobInfo;

        public List<DebugInformation>? DebugInformation { get; } = debugInformations;
    }
}
