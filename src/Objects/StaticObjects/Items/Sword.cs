namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Sword : Item
{
    public Sword(Position position, Map map) : base(position, map)
    {
        Stats.Strength = 3;
        //Stats.Defense = 0;
        //Stats.HealthPoints = 0;
    }

    public override string Name => "Sword";

}

