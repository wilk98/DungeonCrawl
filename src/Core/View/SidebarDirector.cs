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
            _sidebar.AddHorizontalRule();

            var equipment = inventory.Equipment;
            GenerateEquipmentView(equipment);
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

        private void GenerateEquipmentView(Equipment equipment)
        {
            _sidebar.AddCenteredText("Equipment");
            _sidebar.AddLeftAlignedText($" Helmet: {(equipment.Helmet is null ? "Nothing" : equipment.Helmet.Name)}");
            _sidebar.AddLeftAlignedText($" Cuirass: {(equipment.Cuirass is null ? "Nothing" : equipment.Cuirass.Name)}");
            _sidebar.AddLeftAlignedText($" Gloves: {(equipment.Gloves is null ? "Nothing" : equipment.Gloves.Name)}");
            _sidebar.AddLeftAlignedText($" Greaves: {(equipment.Greaves is null ? "Nothing" : equipment.Greaves.Name)}");
            _sidebar.AddLeftAlignedText($" Boots: {(equipment.Boots is null ? "Nothing" : equipment.Boots.Name)}");
            _sidebar.AddLeftAlignedText($" Weapon: {(equipment.Weapon is null ? "Nothing" : equipment.Weapon.Name)}");
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
