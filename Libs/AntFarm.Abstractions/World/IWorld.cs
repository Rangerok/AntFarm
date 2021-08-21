namespace AntFarm.Abstractions.World
{
    public interface IWorld
    {
        public IPathFinder PathFinder { get; }

        public ITerrain Terrain { get; }

        public void LoadWorld(string saveName);

        public void SaveWorld(string saveName);
    }
}