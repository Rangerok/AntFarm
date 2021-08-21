using System.Collections.Generic;
using AntFarm.Abstractions;
using AntFarm.Abstractions.Bot;
using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;
using AntFarm.Bot.SimpleTasks;

namespace AntFarm.Bot
{
    public class BaseBot : IBot
    {
        private readonly int _viewDistance;
        private readonly int _memorySize;

        private readonly Queue<IBotMemory> _memories;
        private readonly Queue<IBotTask> _botTasks;
        
        public Position Position { get; set; }

        public bool IsDead { get; private set; }

        public IBotTask CurrentTask { get; private set; }

        public BaseBot(Position position,
            bool isDead,
            IBotTask currentTask,
            int viewDistance,
            int memorySize)
        {
            Position = position;
            IsDead = isDead;
            CurrentTask = currentTask;
            _viewDistance = viewDistance;
            _memorySize = memorySize;

            _memories = new Queue<IBotMemory>(_memorySize);
            _botTasks = new Queue<IBotTask>(10);
        }

        public virtual void AddMemory(IBotMemory memory)
        {
            if (_memories.Count > _memorySize)
                _memories.Dequeue();

            _memories.Enqueue(memory);
        }

        public virtual void AddTask(IBotTask task)
        {
            _botTasks.Enqueue(task);
        }

        public void ExecuteTask(IWorld world, IPopulation population)
        {
            CurrentTask ??= new WaitTask();

            if (CurrentTask is WaitTask && _botTasks.TryDequeue(out var nextTask))
                CurrentTask = nextTask;

            if (CurrentTask.Execute(world, population, this))
            {
                //TODO Decide task
                CurrentTask = null;
            }
        }
    }
}