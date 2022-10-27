using Dungeon_Crawl.src.Core;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.StaticObjects
{
    internal class Item : StaticObject, IPickable
    {
        private readonly Map map;

        public override bool IsPassable => true;
        public Item(string name, Position position, Map map) : base(position)
        {
            Name = name;
            this.map = map;
        }

        public bool IsPickable => true;

        public string Name { get; internal set; }
        protected override string Symbol { get => "i"; set => throw new NotImplementedException(); }


        public bool PickUp(Player player)
        {
            player.Inventory.AddItem(this);
            map.DeleteAt(Position);
            return true;
        }

        public override void Update()
        {

        }
    }
}
