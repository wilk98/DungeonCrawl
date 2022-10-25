using Dungeon_Crawl.src.Objects.DynamicObjects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using System.Text;

namespace Dungeon_Crawl.src.Core
{
    internal class Display
    {
        private const int _sidebarWidth = 30;
        internal void DisplayView(List<string> view, Inventory inventory, Stats stats)
        {
            var mapHeight = view.Count();
            var mapWidth = view[0].Length;

            var inventoryView = CreateFrame(mapHeight, stats, inventory);

            for (int i = 0; i < mapHeight; i++)
            {
                Console.WriteLine($"{view[i]} {inventoryView[i].PadLeft(Console.WindowWidth - mapWidth - 1)}");
            }
        }
        private List<string> CreateFrame(int height, Stats stats, Inventory inventory)
        {
            var frame = new List<string>();
            var topLine = new StringBuilder().Append('/').Append('-', _sidebarWidth - 2).Append("\\");
            var bottomLine = new StringBuilder().Append('\\').Append('-', _sidebarWidth - 2).Append("/");

            frame.Add(topLine.ToString());
            frame.Add(CenteredText("Stats"));
            frame.Add(LeftAlignedText($" Health: {stats.HealthPoints}"));
            frame.Add(LeftAlignedText($" Strength: {stats.Strength}"));
            frame.Add(LeftAlignedText($" Defence: {stats.Defense}"));
            frame.Add(new StringBuilder().Append("|").Append('-', _sidebarWidth - 2).Append("|").ToString());

            frame.Add(CenteredText("Inventory"));

            var alreadyAdded = frame.Count + 1;
            foreach (var item in inventory.GetItemNames())
            {
                frame.Add(LeftAlignedText($" {item}"));
                alreadyAdded++;
            }

            for (int i = 0; i < height - alreadyAdded; i++)
            {
                frame.Add(new StringBuilder().Append("|").Append(' ', _sidebarWidth - 2).Append("|").ToString());
            }
            frame.Add(bottomLine.ToString());
            return frame;
        }
        private string CenteredText(string text)
        {
            return new StringBuilder().Append("|").Append(' ', _sidebarWidth / 2 - 1 - (int)Math.Ceiling(text.Length / 2f)).Append(text).Append(' ', _sidebarWidth / 2 - 1 - (int)Math.Floor(text.Length / 2f)).Append("|").ToString();
        }
        private string LeftAlignedText(string text)
        {
            return new StringBuilder().Append("|").Append(text.PadRight(_sidebarWidth - 2)).Append("|").ToString();
        }
    }
}