using AntFarm.Abstractions.World;
using RandomAccessPerlinNoise;

namespace AntFarm.AntWorld.World
{
    public class Terrain : ITerrain
    {
        public int Height { get; }

        public int Width { get; }

        public Tile[,] Tiles { get; }

        public Terrain(Tile[,] tiles)
        {
            Tiles = tiles;
            Width = tiles.GetLength(1);
            Height = tiles.GetLength(0);
        }

        public Terrain(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new Tile[height, width];
        }

        public void Generate(int seed)
        {
            var noiseGenerator = new NoiseGenerator(
                seed,
                0.5,
                6,
                new[] { 4, 4 },
                false,
                Interpolations.Cosine);

            var noise = new double[Width, Height];
            noiseGenerator.Fill(noise, new[] { 0L, 0L });

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    var tileType = noise[y, x] switch
                    {
                        var n when n > 0.75 => TileTypes.Rock,
                        var n when n > 0.47 && n <= 0.75 => TileTypes.Dirt,
                        var n when n > 0.39 && n <= 0.47 => TileTypes.Sand,
                        var n when n <= 0.39 => TileTypes.Water,
                    };

                    Tiles[y, x] = new Tile
                    {
                        Type = tileType
                    };
                }
            }
        }
    }
}