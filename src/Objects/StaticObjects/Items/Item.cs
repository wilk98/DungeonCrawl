namespace Dungeon_Crawl.src.Objects.StaticObjects.Items
{
    internal class Item : StaticObject, IPickable
    {
        private readonly Map _map;
        public Stats Stats { get; internal set; }
        public virtual string Name { get; internal set; }

        public override bool IsPassable => true;
        public Item(Position position, Map map) : base(position)
        {
            Stats = new Stats
            {
                HealthPoints = 0,
                Strength = 0,
                Defense = 0
            };
            _map = map;
        }

        public bool IsPickable => true;

        protected override string Symbol => "I";

        public bool PickUp(Player player)
        {
            player.Inventory.AddItem(this);
            _map.DeleteAt(Position);
            return true;
        }

        public override void Update()
        {

        }
    }
}
