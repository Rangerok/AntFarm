using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Abstractions.Bot
{
    public interface IBotTask
    {
        bool Execute(IWorld world, IPopulation population, IBot bot);
    }
}