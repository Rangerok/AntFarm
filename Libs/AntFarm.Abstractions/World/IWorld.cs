using AntFarm.Abstractions.Population;

namespace AntFarm.Abstractions.World
{
    public interface IWorld
    {
        public IPathFinder PathFinder { get; }

        public ITerrain Terrain { get; }

        public void LoadWorld(string path);

        public void SaveWorld(string path);
    }
}