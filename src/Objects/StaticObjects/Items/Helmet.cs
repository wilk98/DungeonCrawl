namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Helmet : Armor
{
    public Helmet(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        Stats.Defense = 2;
        //Stats.HealthPoints = 0;
    }
    public override string Name => "Helmet";

    public override EquipmentType equipmentType => EquipmentType.Helmet;
}