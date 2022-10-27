namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Shield : Item
{
    public Shield(Position position, Map map) : base(position, map)
    {
    }
    public override string Name => "Shield";
}
