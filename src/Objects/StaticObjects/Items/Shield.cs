namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Shield : Armor
{
    public Shield(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        Stats.Defense = 3;
        //Stats.HealthPoints = 0;
    }
    public override string Name => "Shield";

    public override EquipmentType equipmentType => EquipmentType.Weapon;
}
