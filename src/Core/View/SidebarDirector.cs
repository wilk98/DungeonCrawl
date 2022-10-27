using Dungeon_Crawl.src.Objects.DynamicObjects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl.src.Core.View
{
    internal class SidebarDirector
    {
        private readonly Sidebar _sidebar = new();

        public List<string> MakeInfobar(Stats stats, Inventory inventory, int height)
        {
            _sidebar.AddCenteredText("Stats");
            _sidebar.AddLeftAlignedText($" Health: {stats.HealthPoints}");
            _sidebar.AddLeftAlignedText($" Strength: {stats.Strength}");
            _sidebar.AddLeftAlignedText($" Defence: {stats.Defense}");
            _sidebar.AddHorizontalRule();
            _sidebar.AddCenteredText("Inventory");
            foreach (var item in inventory.GetItems())
            {
                if (item == inventory.SelectedItem())
                    _sidebar.AddLeftAlignedText($" > {item.Name}");
                else
                    _sidebar.AddLeftAlignedText($" {item.Name}");
            }
            return _sidebar.CreateFrame(height);
        }
        public List<string> MakeInfoBox(AskDialog info, int height = 5)
        {
            _sidebar.AddCenteredText(info.Text);
            _sidebar.AddEmptyLine();
            _sidebar.AddCenteredText(info.Choices);
            return _sidebar.CreateFrame(height);
        }
    }
}
