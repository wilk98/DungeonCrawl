namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Greaves : Item
{
    public Greaves(Position position, Map map) : base(position, map)
    {
        Stats.Defense += 2;
    }
    public override string Name => "Greaves";
}
