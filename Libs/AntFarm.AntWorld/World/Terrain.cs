using System;
using AntFarm.Abstractions.World;

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
            Tiles = new Tile[width, height];
        }
    }
}