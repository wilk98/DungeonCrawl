namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class DefensePotion : Item
{
    public DefensePotion(Position position, Map map) : base(position, map)
    {
    }
    public override string Name => "Defense Potion";
}
