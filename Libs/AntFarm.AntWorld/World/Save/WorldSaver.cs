using System.IO;
using System.Text.Json;
using AntFarm.Abstractions.World;

namespace AntFarm.AntWorld.World.Save
{
    public class WorldSaver : IWorldSaver
    {
        public Tile[,] LoadWorld(string saveName)
        {
            var saveFile = File.ReadAllText(saveName + ".json");

            //FIXME settings
            var save = JsonSerializer.Deserialize<SaveJson>(saveFile, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            //FIXME null check
            var tiles = new Tile[save.Height, save.Width];

            //FIXME null check
            foreach (var tile in save.Tiles)
            {
                tiles[tile.Y, tile.X] = tile.ToTile();
            }

            return tiles;
        }

        public void SaveWorld(IWorld world, string saveName)
        {
            throw new System.NotImplementedException();
        }
    }
}