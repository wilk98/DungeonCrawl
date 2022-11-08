namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public class Sword : Armor
{
    public Sword(Position position, Map map, Rarity rarity = Rarity.Common) : base(position, map, rarity)
    {
        Stats.Strength = 3;
        //Stats.Defense = 0;
        //Stats.HealthPoints = 0;
    }

    public override string Name => "Sword";

    public override EquipmentType equipmentType => EquipmentType.Weapon;
}

