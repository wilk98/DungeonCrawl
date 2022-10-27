namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class DefensePotion : Item
{
    public DefensePotion(Position position, Map map) : base(position, map)
    {
        Stats.Defense += 1;
    }
    public override string Name => "Defense Potion";
}
