using System.Collections.Generic;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.AntWorld.Population
{
    public class Population : IPopulation
    {
        public IList<IBot> Bots { get; } = new List<IBot>(25);

        public void AddBot(IBot bot)
        {
            Bots.Add(bot);
        }

        public void RemoveBot(IBot bot)
        {
            Bots.Remove(bot);
        }

        public void Update(IWorld world)
        {
            foreach (var bot in Bots)
            {
                bot.ExecuteTask(world, this);
            }
        }
    }
}