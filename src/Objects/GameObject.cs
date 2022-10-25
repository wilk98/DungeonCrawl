namespace Dungeon_Crawl.src.Objects
{
    abstract internal class GameObject
    {
        bool IsSolid { get; }
        protected Position _position;

        protected GameObject(Position position)
        {
            _position = position;
        }

        public abstract void Update();
        public abstract string Render();
    }
}
