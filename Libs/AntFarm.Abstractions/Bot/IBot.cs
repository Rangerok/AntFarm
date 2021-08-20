using AntFarm.Abstractions.Population;
using AntFarm.Abstractions.World;

namespace AntFarm.Abstractions.Bot
{
    public interface IBot
    {
        public Position Position { get; set; }
        
        public bool IsDead { get; }
        
        public IBotTask CurrentTask { get; }

        public void AddMemory(IBotMemory memory);

        public void AddTask(IBotTask task);

        public void ExecuteTask(IWorld world, IPopulation population);
    }
}