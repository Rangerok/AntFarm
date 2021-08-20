namespace AntFarm.Abstractions.World
{
    public interface IPathFinder
    {
        public Position[] FindPath(Position from, Position to);
    }
}