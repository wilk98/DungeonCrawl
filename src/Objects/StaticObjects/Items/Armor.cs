namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Armor : Item
    {
        public Armor(Position position, Map map) : base(position, map)
        {
            //Stats.Strength = 0;
            Stats.Defense = 4;
            //Stats.HealthPoints = 0;
        }
        public override string Name => "Armor";

}

