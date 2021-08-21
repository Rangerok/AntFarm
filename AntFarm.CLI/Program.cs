using System;
using System.Linq;
using System.Threading.Tasks;
using AntFarm.Abstractions;
using AntFarm.AntWorld.Population;
using AntFarm.AntWorld.World;
using AntFarm.AntWorld.World.Save;
using AntFarm.Bot;
using AntFarm.Bot.SimpleTasks;

namespace AntFarm.CLI
{
    public class Program
    {
        private static int width = 64;
        private static int height = 64;

        public static async Task Main(string[] args)
        {
            var world = new World(width,
                height,
                123,
                new WorldSaver());

            var population = new Population();

            var bot = new BaseBot(new Position(1, 1), false, new WalkTask(new Position(55, 55)), 2, 10);
            var bot2 = new BaseBot(new Position(1, 2), false, new WalkTask(new Position(54, 0)), 2, 10);

            population.AddBot(bot);
            population.AddBot(bot2);

            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                for (var row = 0; row < world.Terrain.Tiles.GetLength(0); row++)
                {
                    for (var column = 0; column < world.Terrain.Tiles.GetLength(1); column++)
                    {

                        if (population.Bots.Any(x => x.Position.X == column && x.Position.Y == row))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("B ");
                        }
                        else
                        {
                            (var text, var color) = world.Terrain.Tiles[row, column].Type switch
                            {
                                Abstractions.World.TileTypes.Dirt => ("D ", ConsoleColor.Green),
                                Abstractions.World.TileTypes.Sand => ("S ", ConsoleColor.Yellow),
                                Abstractions.World.TileTypes.Water => ("W ", ConsoleColor.Blue),
                                Abstractions.World.TileTypes.Rock => ("R ", ConsoleColor.Gray),
                                _ => ("U ", ConsoleColor.White),
                            };

                            Console.ForegroundColor = color;
                            Console.Write(text);
                        }
                    }

                    Console.Write(Environment.NewLine);
                }

                await Task.Delay(500);
                Console.Clear();

                population.Update(world);
            }


            Console.ReadKey();
        }
    }
}
