using System.Collections.Generic;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.World;

namespace AntFarm.Abstractions.Population
{
    public interface IPopulation
    {
        public IList<IBot> Bots { get; }

        public void AddBot(IBot bot);

        public void RemoveBot(IBot bot);

        public void Update(IWorld world);
    }
}