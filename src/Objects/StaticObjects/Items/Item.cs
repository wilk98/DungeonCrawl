using Dungeon_Crawl.src.Core;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Objects.StaticObjects.Items
{
    internal class Item : StaticObject, IPickable
    {
        private readonly Map _map;

        public override bool IsPassable => true;
        public Item(Position position, Map map) : base(position)
        {
            _map = map;
        }

        public bool IsPickable => true;

        public virtual string Name { get; internal set; }
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
