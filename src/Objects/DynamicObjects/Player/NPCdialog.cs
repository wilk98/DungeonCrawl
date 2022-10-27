using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawl.src.Core.View;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class NPCdialog : Controller<NPC>
    {
        public NPCdialog(Map map, Player player) : base(map, player)
        {
        }

        protected override Info GetInfo(NPC foundedItem)
        {
            return new Info(foundedItem.GetNextPhrase(), new Tuple<string, string>("ok", "ok"), OnFound);
        }

        protected override NPC? SearchItem()
        {
            var foundItem = base.SearchItem();
            if (foundItem is null) return null;
            return foundItem.Finished ? null : foundItem;
        }

        internal override void OnFound(bool accepted)
        {
        }
    }
}
