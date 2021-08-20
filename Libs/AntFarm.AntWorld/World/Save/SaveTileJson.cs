using AntFarm.Abstractions.World;

namespace AntFarm.AntWorld.World.Save
{
    public record SaveTileJson
    {
        public int X { get; set; }

        public int Y { get; set; }

        public TileTypes Type { get; set; }

        public Tile ToTile()
        {
            return new Tile
            {
                Type = Type,
            };
        }
    }
}