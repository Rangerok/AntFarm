namespace AntFarm.Abstractions.World
{
    public record Tile
    {
        public TileTypes Type { get; set; }

        public bool IsWalkable()
        {
            return Type != TileTypes.Water
                   && Type != TileTypes.Rock;
        }
    }
}