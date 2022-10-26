namespace Dungeon_Crawl.src.Monsters;

internal class Archer : Monster
{
    public Archer(Position position) : base(position)
    {
    }

    protected override string Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override string Render()
    {
        throw new NotImplementedException();
    }

    public override void Update()
    {
        throw new NotImplementedException();
    }
}

