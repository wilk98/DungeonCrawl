﻿namespace Dungeon_Crawl.src.Core.View
{
    internal class SidebarDirector
    {
        private readonly Sidebar _sidebar = new();
        private readonly ProgressBar _progressBar = new();

        public List<string> MakeInfobar(Stats stats, Inventory inventory, int height, LevelUp level)
        {
            _sidebar.AddCenteredText("Stats");
            _sidebar.AddLeftAlignedText($" Level: {level.level}");;
            _sidebar.AddLeftAlignedText($" Experience: {level.experience}/{level.experienceRequired}");
            _sidebar.AddLeftAlignedText(_progressBar.DrawBar(level.experience,level.experienceRequired));
            _sidebar.AddLeftAlignedText($" Health: {stats.HealthPoints}/{level.maxHealtPoints}");
            _sidebar.AddLeftAlignedText(_progressBar.DrawBar(stats.HealthPoints, level.maxHealtPoints));
            _sidebar.AddLeftAlignedText($" Strength: {stats.Strength}");
            _sidebar.AddLeftAlignedText($" Defense: {stats.Defense}");
            _sidebar.AddHorizontalRule();
            _sidebar.AddCenteredText("Inventory");
            foreach (var item in inventory.GetItems())
            {
                if (item == inventory.SelectedItem)
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
        public List<string> MakeInfobarFight(Stats stats, Stats monsterStats, int height, LevelUp level, int maxMonsterHp)
        {
            _sidebar.AddCenteredText("Monster Stats");
            _sidebar.AddLeftAlignedText($" Health: {monsterStats.HealthPoints}");
            _sidebar.AddLeftAlignedText(_progressBar.DrawBar(monsterStats.HealthPoints, maxMonsterHp));
            _sidebar.AddLeftAlignedText($" Strength: {monsterStats.Strength}");
            _sidebar.AddLeftAlignedText($" Defense: {monsterStats.Defense}");
            _sidebar.AddHorizontalRule();
            _sidebar.AddCenteredText(" Stats");
            _sidebar.AddLeftAlignedText($" Health: {stats.HealthPoints}");
            _sidebar.AddLeftAlignedText(_progressBar.DrawBar(stats.HealthPoints, level.maxHealtPoints));
            _sidebar.AddLeftAlignedText($" Strength: {stats.Strength}");
            _sidebar.AddLeftAlignedText($" Defense: {stats.Defense}");
            _sidebar.AddHorizontalRule();
            return _sidebar.CreateFrame(height);
        }
    }
}
