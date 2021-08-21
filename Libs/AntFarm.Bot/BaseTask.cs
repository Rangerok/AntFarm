using System.Collections.Generic;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Bot
{
    public abstract class BaseTask : IBotTask
    {
        protected readonly Queue<IBotTask> _subTasksQueue;

        private bool _isInitialized = false;

        protected BaseTask()
        {
            _subTasksQueue = new Queue<IBotTask>(15);
        }

        public bool Execute(IWorld world, IPopulation population, IBot bot)
        {
            if (!_isInitialized)
                InitializeTask(world, population, bot);

            if (_subTasksQueue.TryPeek(out var subTask))
            {
                if (subTask.Execute(world, population, bot))
                    _subTasksQueue.Dequeue();

                return false;
            }

            return ExecuteInternal(world, population, bot);
        }

        protected virtual void InitializeTask(IWorld world, IPopulation population, IBot bot)
        {
            //Do nothing by default
        }

        protected abstract bool ExecuteInternal(IWorld world, IPopulation population, IBot bot);
    }
}