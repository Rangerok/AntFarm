namespace AntFarm.Abstractions.World
{
    public interface ITerrain
    {
        public int Height { get; }

        public int Width { get; }

        public Tile[,] Tiles { get; }

        public void Generate(int seed);
    }
}