namespace Dungeon_Crawl.src.Objects
{
    abstract internal class GameObject
    {
        bool IsSolid { get; }

        private string Symbol { get; set; }
        protected Position _position;

        protected GameObject(Position position)
        {
            _position = position;
        }

        public abstract void Update();
        public abstract string Render();
        public override string ToString()
        {
            return Symbol;
        }
    }
}
