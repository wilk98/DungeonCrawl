namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Helmet : Item
{
    public Helmet(Position position, Map map) : base(position, map)
    {
        Stats.Defense += 2;
    }
    public override string Name => "Helmet";
}