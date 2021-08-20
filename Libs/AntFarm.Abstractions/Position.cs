namespace AntFarm.Abstractions
{
    public record Position
    {
        public Position()
        {

        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }
        
        public int Y { get; init; }
    }
}