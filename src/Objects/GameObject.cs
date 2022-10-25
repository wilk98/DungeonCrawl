namespace Dungeon_Crawl.src.Objects
{
    abstract internal class GameObject
    {
        bool IsPassable { get; }

        abstract protected string Symbol { get; set; }
        public Position Position { get; protected set; }

        protected GameObject(Position position)
        {
            Position = position;
        }

        public abstract void Update();
        public abstract string Render();
        public override string ToString()
        {
            return Symbol;
        }
    }
}
