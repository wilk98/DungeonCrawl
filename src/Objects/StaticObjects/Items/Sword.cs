namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Sword : Armor
{
    public Sword(Position position, Map map) : base(position, map)
    {
        Stats.Strength = 3;
        //Stats.Defense = 0;
        //Stats.HealthPoints = 0;
    }

    public override string Name => "Sword";

    public override EquipmentType equipmentType => EquipmentType.Weapon;
}

