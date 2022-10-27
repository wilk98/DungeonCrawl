namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class ItemController : Controller
    {
        public ItemController(Map map, Player player) : base(map, player)
        {

        }

        protected override Item? SearchItem()
        {
            {
                if (GetItem(new Position(player.Position.X, player.Position.Y + 1)) is Item item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X, player.Position.Y - 1)) is Item item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X + 1, player.Position.Y)) is Item item) return item;
            }
            {
                if (GetItem(new Position(player.Position.X - 1, player.Position.Y)) is Item item) return item;
            }
            return null;
        }

        protected override Item? GetItem(Position position)
        {
            if (map.At(position) is Item)
            {
                return (Item) map.At(position);
            }
            return null;
        }

        protected override Info GetInfo(Item item)
        {
             return new Info($"Pick {item.Name}?", new Tuple<string, string>("Yes", "No"), PickItemInfo);
        }

        internal override void PickItemInfo(bool accepted)
        {
            if (accepted)
            {
                var item = SearchItem();
                item?.PickUp(player);
            }
            else
            {
                IgnoreItemSearching = 2;
            }
        }
    }
}