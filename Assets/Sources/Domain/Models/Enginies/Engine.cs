namespace Sources.Domain.Models.Engines
{
    public class Engine : IEngine
    {
        public Engine(int speed)
        {
            Speed = speed;
        }

        public int Speed { get; }
    }
}