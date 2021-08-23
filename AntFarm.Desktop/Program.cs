using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using AntFarm.Abstractions;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;
using AntFarm.AntWorld.Population;
using AntFarm.AntWorld.World;
using AntFarm.AntWorld.World.Save;
using AntFarm.Bot;
using AntFarm.Bot.SimpleTasks;
using Perlin;
using Perlin.Display;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Veldrid;

namespace AntFarm.Desktop
{
    public class Program
    {
        private static int tileSize = 6;

        private static int width = 128;
        private static int height = 128;

        private static ResourceSet dirtTexture;
        private static ResourceSet grassTexture;
        private static ResourceSet sandTexture;
        private static ResourceSet rockTexture;
        private static ResourceSet waterTexture;
        private static ResourceSet unknownTexture;
        private static ResourceSet botTexture;

        private static IWorld world = new World(width, height, 123, new WorldSaver());
        private static IPopulation population = new Population();

        private static Timer updateTimer = new(500);

        public static async Task Main(string[] args)
        {
            PerlinApp.Start(tileSize * width, tileSize * height, "AntFarm", OnInit);
        }

        private static void OnInit()
        {
            PerlinApp.Stage.BackgroundColor = new Rgb24(200, 200, 200);

            dirtTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.FromRgb(236, 210, 143));
            grassTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.FromRgb(91, 133, 79));
            sandTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.FromRgb(255, 240, 140));
            rockTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.Gray);
            waterTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.FromRgb(118, 143, 184));
            unknownTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.White);
            botTexture = PerlinApp.ImageManager.CreateColoredTexture((uint)tileSize, (uint)tileSize, Color.Black);
            
            var bot = new BaseBot(new Position(1, 1), false, new WalkTask(new Position(55, 55)), 2, 10);
            var bot2 = new BaseBot(new Position(1, 2), false, new WalkTask(new Position(54, 0)), 2, 10);

            population.AddBot(bot);
            population.AddBot(bot2);

            for (var row = 0; row < world.Terrain.Tiles.GetLength(0); row++)
            {
                for (var column = 0; column < world.Terrain.Tiles.GetLength(1); column++)
                {
                    var sp = new Sprite(tileSize, tileSize, Color.White)
                    {
                        X = column * tileSize,
                        Y = row * tileSize
                    };

                    PerlinApp.Stage.AddChild(sp);

                    sp.EnterFrameEvent += (target, secs) =>
                    {
                        var targetCol = (int)target.X / tileSize;
                        var targetRow = (int)target.Y / tileSize;

                        ResourceSet texture;

                        if (population.Bots.Any(x => x.Position.X == targetCol && x.Position.Y == targetRow))
                        {
                            texture = botTexture;
                        }
                        else
                        {
                            texture = GetTexture(world.Terrain.Tiles[targetRow, targetCol].Type);
                        }

                        if (target.ResSet != texture)
                            target.ResSet = texture;
                    };
                }
            }

            updateTimer.Elapsed += (sender, e) =>
            {
                population.Update(world);
            };
            updateTimer.Start();

            PerlinApp.ShowStats(HorizontalAlignment.Right);
        }

        private static ResourceSet GetTexture(TileTypes type)
        {
            return type switch
            {
                Abstractions.World.TileTypes.Dirt => dirtTexture,
                Abstractions.World.TileTypes.Grass => grassTexture,
                Abstractions.World.TileTypes.Sand => sandTexture,
                Abstractions.World.TileTypes.Water => waterTexture,
                Abstractions.World.TileTypes.Rock => rockTexture,
                _ => unknownTexture,
            };
        }
    }
}
