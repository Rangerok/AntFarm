using System.Collections.Generic;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Bot
{
    public abstract class BaseTask : IBotTask
    {
        protected readonly Queue<IBotTask> _subTasksQueue;

        protected BaseTask()
        {
            _subTasksQueue = new Queue<IBotTask>(15);
        }

        public bool Execute(IWorld world, IPopulation population, IBot bot)
        {
            if (_subTasksQueue.TryDequeue(out var subTask))
            {
                subTask.Execute(world, population, bot);

                return false;
            }

            return ExecuteInternal(world, population, bot);
        }

        protected abstract bool ExecuteInternal(IWorld world, IPopulation population, IBot bot);
    }
}