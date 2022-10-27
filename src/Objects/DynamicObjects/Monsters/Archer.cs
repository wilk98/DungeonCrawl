namespace Dungeon_Crawl.src.Monsters;

internal class Archer : Monster
{
    public override Stats Stats { get; internal set; }
    public Archer(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 50;
        Stats.Strength = 10;
        Stats.Defense = 2;
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

