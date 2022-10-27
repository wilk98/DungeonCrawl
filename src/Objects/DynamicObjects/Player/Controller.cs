namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal abstract class Controller<T>
    {
        protected readonly Map map;
        protected readonly Player player;
        protected int IgnoreItemSearching = 0;

        protected Controller(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }


        internal virtual State PickItem()
        {
            var item = SearchItem();
            IgnoreItemSearching = Math.Max(0, --IgnoreItemSearching);
            if (item is null || IgnoreItemSearching != 0) return State.Game;
            player.Info = GetInfo(item);
            return State.Info;
        }

        internal abstract void OnFound(bool accepted);
        protected abstract Info GetInfo(T foundedItem);
        protected abstract T? GetItem(Position position);
        protected abstract T? SearchItem();
    }
}