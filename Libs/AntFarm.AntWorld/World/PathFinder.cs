using System.Linq;
using AntFarm.Abstractions;
using AntFarm.Abstractions.World;
using AStar;
using Position = AntFarm.Abstractions.Position;

namespace AntFarm.AntWorld.World
{
    public class PathFinder : IPathFinder
    {
        private readonly WorldGrid _worldGrid;
        private readonly AStar.PathFinder _pathFinder;

        public PathFinder(ITerrain terrain)
        {
            _worldGrid = new WorldGrid(terrain.Height, terrain.Width);

            for (var row = 0; row < terrain.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < terrain.Tiles.GetLength(1); column++)
                {
                    _worldGrid[row, column] = terrain.Tiles[row, column].IsWalkable() ? 1 : 0;
                }
            }

            _pathFinder = new AStar.PathFinder(_worldGrid);
        }

        public PathFinder(int width, int height)
        {
            _worldGrid = new WorldGrid(height, width);
            _pathFinder = new AStar.PathFinder(_worldGrid);
        }

        public Position[] FindPath(Position from, Position to)
        {
            var path = _pathFinder.FindPath(new AStar.Position(from.Y, from.X), new AStar.Position(to.Y, to.X));

            return path
                .Select(x => new Position
                {
                    X = x.Column,
                    Y = x.Row,
                })
                .ToArray();
        }
    }
}