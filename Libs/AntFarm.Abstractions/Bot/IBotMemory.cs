namespace AntFarm.Abstractions.Bot
{
    public interface IBotMemory
    {
        public int Time { get; }
        
        public Position Position { get; }
        
        public MemoryTypes MemoryType { get; }
    }
}