namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Greaves : Item
{
    public Greaves(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        Stats.Defense = 2;
        //Stats.HealthPoints = 0;
    }
    public override string Name => "Greaves";
}
