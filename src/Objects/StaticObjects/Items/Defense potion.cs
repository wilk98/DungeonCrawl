namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class DefensePotion : Item
{
    public DefensePotion(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        Stats.Defense = 1;
        //Stats.HealthPoints = 0;
    }
    public override string Name => "Defense Potion";
}
