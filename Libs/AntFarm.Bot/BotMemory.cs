using AntFarm.Abstractions;
using AntFarm.Abstractions.Bot;

namespace AntFarm.Bot
{
    public record BotMemory : IBotMemory
    {
        public BotMemory(int time,
            Position position,
            MemoryTypes memoryType)
        {
            Time = time;
            Position = position;
            MemoryType = memoryType;
        }

        public int Time { get; }
        
        public Position Position { get; }
        
        public MemoryTypes MemoryType { get; }
    }
}