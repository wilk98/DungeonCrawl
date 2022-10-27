namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal abstract class Controller
    {
        protected readonly Map map;
        protected readonly Player player;
        protected int IgnoreItemSearching = 0;

        protected Controller(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }


        internal State PickItem()
        {
            var item = SearchItem();
            IgnoreItemSearching = Math.Max(0, --IgnoreItemSearching);
            if (item is null || IgnoreItemSearching != 0) return State.Game;
            player.Info = GetInfo(item);
            return State.Info;
        }

        internal abstract void PickItemInfo(bool accepted);
        protected abstract Info GetInfo(Item item);
        protected abstract Item? GetItem(Position position);
        protected abstract Item? SearchItem();
    }
}