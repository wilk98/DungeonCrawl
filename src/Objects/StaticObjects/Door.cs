namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Door : StaticObject
    {
        public Door(Position position) : base(position)
        {
        }

        protected override string Symbol => "D";
    }
}
