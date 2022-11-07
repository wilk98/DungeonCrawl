namespace Dungeon_Crawl.src.Objects.StaticObjects.Items
{
    internal abstract class Item : StaticObject, IPickable
    {
        private readonly Map _map;
        public Stats Stats { get; internal set; }
        public abstract string Name { get; }

        public override bool IsPassable => true;
        public Item(Position position, Map map) : base(position)
        {
            _map = map;
            Stats = new Stats();
        }

        public bool IsPickable => true;

        protected override string Symbol => "I";

        public bool PickUp(Player player)
        {
            player.Inventory.AddItem(this);
            _map.DeleteAt(Position);
            return true;
        }

        public virtual void Use(Player player)
        {
            player.Stats.UpdateStats(Stats.HealthPoints, Stats.Strength, Stats.Defense);
            player.Inventory.RemoveItem(this);
        }

        public override void Update()
        {

        }
    }
}
