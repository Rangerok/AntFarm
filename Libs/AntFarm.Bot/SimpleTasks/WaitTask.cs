using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Bot.SimpleTasks
{
    public class WaitTask : BaseTask
    {
        protected override bool ExecuteInternal(IWorld world, IPopulation population, IBot bot)
        {
            //DO NOTHING
            return true;
        }
    }
}