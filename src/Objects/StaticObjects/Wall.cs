namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Wall : StaticObject
    {
        public Wall(Position position) : base(position)
        {
        }

        protected override string Symbol { get => "#"; set => throw new NotImplementedException(); }
    }
}
