namespace Dungeon_Crawl.src.Objects.DynamicObjects;
internal abstract class Monster : DynamicObject
{
    public virtual Stats Stats { get; internal set; }
    protected Monster(Position position) : base(position)
    {

    }
}

