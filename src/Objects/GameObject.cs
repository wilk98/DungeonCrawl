namespace Dungeon_Crawl.src.Objects
{
    abstract internal class GameObject
    {
        bool IsSolid { get; }
        protected Position _position;
        public abstract void Update();
        public abstract string Render();
    }
}
