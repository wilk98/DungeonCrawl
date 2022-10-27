namespace Dungeon_Crawl.src.Monsters;

internal class Warrior : Monster
{
    public override Stats Stats { get; internal set; }
    public Warrior(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 70;
        Stats.Strength = 15;
        Stats.Defense = 3;
    }

    protected override string Symbol { get => "W"; set => throw new NotImplementedException(); }

    public override void Update()
    {
        return;
    }

    public override string Render()
    {
        return "";
    }
}

