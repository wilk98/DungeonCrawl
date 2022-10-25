namespace Dungeon_Crawl.src.Monsters;
internal abstract class Monster : DynamicObject
{
    protected Monster(Position position) : base(position)
    {
    }
}

