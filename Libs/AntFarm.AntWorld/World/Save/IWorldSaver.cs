using AntFarm.Abstractions.World;

namespace AntFarm.AntWorld.World.Save
{
    public interface IWorldSaver
    {
        Tile[,] LoadWorld(string saveName);

        void SaveWorld(IWorld world, string saveName);
    }
}