using System.Linq;
using AntFarm.Abstractions;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Bot.SimpleTasks
{
    public class WalkTask : BaseTask
    {
        private readonly Position _targetPosition;

        public WalkTask(Position position)
        {
            _targetPosition = position;
        }

        protected override bool ExecuteInternal(IWorld world, IPopulation population, IBot bot)
        {
            if (bot.Position == _targetPosition)
                return true;

            var paths = world.PathFinder.FindPath(bot.Position, _targetPosition);

            if (paths != null && paths.Any())
            {
                bot.Position = paths.Skip(1).First();

                return false;
            }

            //TODO LOG path unreachable
            return true;
        }
    }
}