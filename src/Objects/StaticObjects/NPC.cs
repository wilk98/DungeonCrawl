namespace Dungeon_Crawl.src.Objects.StaticObjects;
internal class NPC : StaticObject
{
    public NPC(Position position) : base(position)
    {
    }

    protected override string Symbol { get => "N"; set => throw new NotImplementedException(); }
}

