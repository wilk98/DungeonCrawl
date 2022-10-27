namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Shield : Item
{
    public Shield(Position position, Map map) : base(position, map)
    {
        Stats.Defense += 3;
    }
    public override string Name => "Shield";
}
