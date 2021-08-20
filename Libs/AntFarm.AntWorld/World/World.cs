using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;
using AntFarm.AntWorld.World.Save;

namespace AntFarm.AntWorld.World
{
    public class World : IWorld
    {
        public IPathFinder PathFinder { get; private set; }

        public ITerrain Terrain { get; private set; }

        public World(string savePath)
        {
            LoadWorld(savePath);
        }

        public World(int width, int height)
        {
            Terrain = new Terrain(width, height);
            PathFinder = new PathFinder(Terrain);
        }

        public void LoadWorld(string path)
        {
            //FIXME 
            var saveFile = File.ReadAllText(path);

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

            Terrain = new Terrain(tiles);
            PathFinder = new PathFinder(Terrain);
        }

        public void SaveWorld(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}