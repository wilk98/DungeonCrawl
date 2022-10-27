using Dungeon_Crawl.src.Core;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class ItemController
    {
        private readonly Map map;
        private readonly Player player;
        private int IgnoreItemSearching = 0;

        public ItemController(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }

        private Item? SearchItem()
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

        private Item? GetItem(Position position)
        {
            if (map.At(position) is Item)
            {
                return (Item) map.At(position);
            }
            return null;
        }

        internal State PickItem()
        {
            var item = SearchItem();
            IgnoreItemSearching = Math.Max(0, --IgnoreItemSearching);
            if (item is null || IgnoreItemSearching != 0) return State.Game;


            player.Info = new Info($"Pick {item.Name}?", new Tuple<string, string>("Yes", "No"), PickItemInfo);
            return State.Info;
        }
        internal void PickItemInfo(bool accepted)
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