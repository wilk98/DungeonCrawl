namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Helmet : Armor
{
    public Helmet(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Defense = 2;
    }
    public override string Name => base.Name + "Helmet";

    public override EquipmentType equipmentType => EquipmentType.Helmet;
}