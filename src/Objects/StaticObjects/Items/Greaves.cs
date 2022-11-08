namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Greaves : Armor
{
    public Greaves(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        //Stats.Strength = 0;
        Stats.Defense = 2;
        //Stats.HealthPoints = 0;
    }
    public override string Name => base.Name + "Greaves";

    public override EquipmentType equipmentType => EquipmentType.Greaves;
}
