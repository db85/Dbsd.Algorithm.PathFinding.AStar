using System.Numerics;

namespace Dbsd.Algorithm.PathFinding.AStar.Test
{
    public class AStarTests
    {
        private AStartPathfinding AStartPathfinding { get; set; }
        private SimpleAStartJobImpl SimpleAStartJobImpl { get; set; }

        [SetUp]
        public void Setup()
        {
            SimpleAStartJobImpl = new SimpleAStartJobImpl();
            AStartPathfinding = new AStartPathfinding(SimpleAStartJobImpl);
        }

        [Test]
        public void TestStraightPath()
        {
            var startPosition = Vector3.Zero;
            var target = new Vector3(0, 0, 10);
            var result = AStartPathfinding.FindPath(new SimpleJobInfo(startPosition: startPosition, targetPosition: target), new CancellationToken());

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.That(result.Iterations, Is.EqualTo(10));

            var path = AStartPathfinding.GetPath<SimpleAStarNode>(result.Result);
            Assert.NotNull(path);
            Assert.That(path.Count, Is.EqualTo(11));

            Assert.That(path.First().Position, Is.EqualTo(startPosition));
            Assert.That(path.Last().Position, Is.EqualTo(target));
        }

        [Test]
        public void TestDiagonlPath()
        {
            var startPosition = Vector3.Zero;
            var target = new Vector3(10, 0, 10);
            var result = AStartPathfinding.FindPath(new SimpleJobInfo(startPosition: startPosition, targetPosition: target), new CancellationToken());

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.That(result.Iterations, Is.EqualTo(20));

            var path = AStartPathfinding.GetPath<SimpleAStarNode>(result.Result);
            Assert.NotNull(path);
            Assert.That(path.Count, Is.EqualTo(21));

            Assert.That(path.First().Position, Is.EqualTo(startPosition));
            Assert.That(path.Last().Position, Is.EqualTo(target));
        }

        [Test]
        public void TestTargetNotFound()
        {
            var startPosition = Vector3.Zero;
            var target = new Vector3(10.5f, 0, 10);
            var result = AStartPathfinding.FindPath(new SimpleJobInfo(startPosition: startPosition, targetPosition: target), new CancellationToken());

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.That(result.Iterations, Is.EqualTo(SimpleAStartJobImpl.MaximumIteration));
        }
    }
}