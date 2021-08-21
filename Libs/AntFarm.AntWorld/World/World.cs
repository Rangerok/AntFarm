using AntFarm.Abstractions.World;
using AntFarm.AntWorld.World.Save;

namespace AntFarm.AntWorld.World
{
    public class World : IWorld
    {
        private readonly IWorldSaver _worldSaver;

        public IPathFinder PathFinder { get; private set; }

        public ITerrain Terrain { get; private set; }

        public World(string saveName,
            IWorldSaver worldSaver)
        {
            _worldSaver = worldSaver;
            LoadWorld(saveName);
        }

        public World(int width,
            int height,
            int seed,
            IWorldSaver worldSaver)
        {
            _worldSaver = worldSaver;
            Terrain = new Terrain(width, height);

            Terrain.Generate(seed);

            PathFinder = new PathFinder(Terrain);
        }
       
        public void LoadWorld(string saveName)
        {
            var tiles = _worldSaver.LoadWorld(saveName);

            Terrain = new Terrain(tiles);
            PathFinder = new PathFinder(Terrain);
        }

        public void SaveWorld(string saveName)
        {
            throw new System.NotImplementedException();
        }
    }
}