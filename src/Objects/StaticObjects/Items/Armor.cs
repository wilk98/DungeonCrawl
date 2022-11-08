namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
public abstract class Armor : Item
{
    public Armor(Position position, Map map) : base(position, map)
    {
        //Stats.Strength = 0;
        Stats.Defense = 4;
        //Stats.HealthPoints = 0;
    }

    public abstract EquipmentType equipmentType { get; }
    public override State Use(Player player)
    {
        player.Inventory.Equipment.Equip(this);
        return State.Game;
    }
}

