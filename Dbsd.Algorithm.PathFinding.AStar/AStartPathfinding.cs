namespace Dbsd.Algorithm.PathFinding.AStar
{
    public class AStartPathfinding(IAStarJobImpl aStarJobImpl)
    {
        private IAStarJobImpl AStarJobImpl { get; } = aStarJobImpl;

        public AStarResult? FindPath(AStarJobInfo jobInfo, CancellationToken cancellationToken)
        {
            int i = 0;
            var checkedNodes = new Dictionary<string, IAStarNode>();

            var openNodes = AStarJobImpl.Inflate(jobInfo, parent: null).ToDictionary(n => n.Id, n => n);

            IAStarNode? currentNode = null;

            List<DebugInformation>? debugInformation = jobInfo.Debug ? [] : null;


            while (true)
            {
                if (cancellationToken.IsCancellationRequested || openNodes.Count <= 0)
                    return null;

                var nodePair = openNodes.MinBy(n => n.Value.TotalCosts);
                currentNode = nodePair.Value;


                if (AStarJobImpl.HasTargetReached(jobInfo, nodePair.Value))
                    return new AStarResult(jobInfo, currentNode, i, debugInformation);

                var parent = nodePair.Value;
                var neighbours = AStarJobImpl.Inflate(jobInfo, parent: parent);

                debugInformation?.Add(new(currentNode, neighbours.Cast<IAStarNode>().ToList()));

                foreach (var node in neighbours)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return null;

                    IAStarNode? exisingNode;
                    if (checkedNodes.ContainsKey(node.Id))
                        exisingNode = checkedNodes[node.Id];
                    else exisingNode = openNodes.GetValueOrDefault(node.Id);

                    if (exisingNode == null)
                    {
                        openNodes.Add(node.Id, node);
                    }
                    else
                    {
                        var existingCosts = exisingNode.TotalCosts;
                        var newCosts = node.TotalCosts;
                        if (newCosts < existingCosts)
                        {
                            openNodes.Remove(exisingNode.Id);
                            checkedNodes.Remove(exisingNode.Id);
                            openNodes.Add(node.Id, node);
                        }
                    }
                }

                checkedNodes.Add(nodePair.Key, nodePair.Value);

                openNodes.Remove(nodePair.Key);

                i++;
                if (i >= AStarJobImpl.MaximumIteration)
                {
                    var nodes = checkedNodes.OrderBy(c => c.Value.TotalCosts).ToList();
                    return new AStarResult(jobInfo, nodes.First().Value, AStarJobImpl.MaximumIteration, debugInformation);
                }
            }
        }

        public static List<T> GetPath<T>(IAStarNode lastnode) where T : IAStarNode
        {
            IAStarNode? current = lastnode;

            var nodes = new List<T>();
            while (current != null)
            {
                nodes.Add((T)current);
                current = current.Parent;
            }
            nodes.Reverse();

            return nodes;
        }
    }
}
