namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class HealthPotion : Item
{
    public HealthPotion(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        //Stats.Defense = 0;
        Stats.HealthPoints = 20;
    }
    public override string Name => "Health Potion";

}
