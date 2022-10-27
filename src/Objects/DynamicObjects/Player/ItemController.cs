using Dungeon_Crawl.src.Core.View;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class ItemController : Controller<Item>
    {
        public ItemController(Map map, Player player) : base(map, player)
        {

        }

        internal override void OnFound(bool accepted)
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

        protected override Info GetInfo(Item foundedItem)
        {
            return new Info($"Pick {foundedItem.Name}?", new Tuple<string, string>("Yes", "No"), OnFound);
        }
    }
}