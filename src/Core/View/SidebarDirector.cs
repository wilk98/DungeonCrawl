namespace Dungeon_Crawl.src.Core.View
{
    internal class SidebarDirector
    {
        private readonly Sidebar _sidebar = new();

        public List<string> MakeInfobar(Stats stats, Inventory inventory, int height)
        {
            GenerateStatsView(stats, "Stats");
            _sidebar.AddHorizontalRule();
            GenerateInventoryView(inventory);

            return _sidebar.CreateFrame(height);
        }

        private void GenerateInventoryView(Inventory inventory)
        {
            _sidebar.AddCenteredText("Inventory");
            foreach (var item in inventory.GetItems())
            {
                if (item == inventory.SelectedItem)
                    _sidebar.AddLeftAlignedText($" > {item.Name}");
                else
                    _sidebar.AddLeftAlignedText($" {item.Name}");
            }
        }

        private void GenerateStatsView(Stats stats, string centeredText)
        {
            _sidebar.AddCenteredText(centeredText);
            _sidebar.AddLeftAlignedText($" Health: {stats.HealthPoints}");
            _sidebar.AddLeftAlignedText($" Strength: {stats.Strength}");
            _sidebar.AddLeftAlignedText($" Defense: {stats.Defense}");
        }

        }

        public List<string> MakeInfoBox(AskDialog info, int height = 5)
        {
            _sidebar.AddCenteredText(info.Text);
            _sidebar.AddEmptyLine();
            _sidebar.AddCenteredText(info.Choices);
            return _sidebar.CreateFrame(height);
        }
        public List<string> MakeInfobarFight(Stats stats, Stats monsterStats, int height)
        {
            GenerateStatsView(monsterStats, "Monster Stats");
            _sidebar.AddHorizontalRule();
            GenerateStatsView(stats, "Stats");
            _sidebar.AddHorizontalRule();
            return _sidebar.CreateFrame(height);
        }
    }
}
