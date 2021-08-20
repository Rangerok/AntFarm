using System;

namespace AntFarm.AntWorld.World.Save
{
    public class SaveJson
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public SaveTileJson[] Tiles { get; set; } = Array.Empty<SaveTileJson>();
    }
}