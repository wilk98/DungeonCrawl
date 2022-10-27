namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class StrengthPotion : Item
{
    public StrengthPotion(Position position, Map map) : base(position, map)
    {
        Stats.Strength += 5;
    }
    public override string Name => "Strength Potion";
}