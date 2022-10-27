namespace Dungeon_Crawl.src.Objects.StaticObjects.Items;
internal class Armor : Item
    {
        public Armor(Position position, Map map) : base(position, map)
        {
            Stats.Defense += 3;
        }
        public override string Name => "Armor";

}

