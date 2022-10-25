using Dungeon_Crawl.src.Objects.DynamicObjects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using System.Text;

namespace Dungeon_Crawl.src.Core.View
{
    internal class Display
    {
        internal void DisplayView(List<string> view, List<string> sidebar)
        {
            var mapHeight = view.Count();
            var mapWidth = view[0].Length;

            for (int i = 0; i < mapHeight; i++)
            {
                Console.WriteLine($"{view[i]} {sidebar[i].PadLeft(Console.WindowWidth - mapWidth - 1)}");
            }
        }
    }
}