namespace Dungeon_Crawl.src.Monsters;

internal class Archer : Monster
{
    public Archer(Position position) : base(position)
    {
    }

    protected override string Symbol { get => "A"; set => throw new NotImplementedException(); }

    public override string Render()
    {
        return Symbol;
    }

    public override void Update()
    {
    }
}

