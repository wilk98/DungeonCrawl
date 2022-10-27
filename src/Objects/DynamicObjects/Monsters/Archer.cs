namespace Dungeon_Crawl.src.Monsters;

internal class Archer : Monster
{
    public Archer(Position position) : base(position)
    {
    }

    protected override string Symbol => "A";

    public override void Update()
    {
        return;
    }

    public override string Render()
    {
        return "";
    }
}

