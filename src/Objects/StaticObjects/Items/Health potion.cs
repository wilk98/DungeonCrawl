namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class HealthPotion : Item
{
    public HealthPotion(Position position, Map map) : base(position, map)
    {
        Stats.HealthPoints += 50;
    }
    public override string Name => "Health Potion";
}
