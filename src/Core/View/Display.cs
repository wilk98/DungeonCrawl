using Dungeon_Crawl.src.Objects.DynamicObjects;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;
using System.Diagnostics;
using System.Text;

namespace Dungeon_Crawl.src.Core.View;

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
    internal void DisplayInfo(List<string> view, List<string> sidebar, List<string> info)
    {
        /* info = new()
        {
            "/--------------------------\\",
            "|  Do you want pick sword? |",
            "|                          |",
            "|                          |",
            "|    <Yes>        <No>     |",
            "\\--------------------------/",
        }; */
        var mapHeight = view.Count();
        var mapWidth = view[0].Length;

        var infoStartY = (mapHeight - info.Count()) / 2;
        var infoStartX = (mapWidth - info[0].Length) / 2;

        var viewWithInfo = new List<string>();
        var infoIndex = 0;
        for (int i = 0; i < view.Count(); i++)
        {
            if (i > infoStartY && i <= infoStartY + info.Count())
            {
                var beforeInfo = view[i][..infoStartX];
                var Info = info[infoIndex];
                var afterInfo = view[i][(infoStartX + info[0].Length)..];

                viewWithInfo.Add(beforeInfo + Info + afterInfo);
                infoIndex++;
            }
            else
            {
                viewWithInfo.Add(view[i]);
            }
        }

        for (int i = 0; i < mapHeight; i++)
        {
            Console.WriteLine($"{viewWithInfo[i]} {sidebar[i].PadLeft(Console.WindowWidth - mapWidth - 1)}");
        }
    }
    internal void DisplayOptionsFight()
    {
        Console.WriteLine("\n1. Go forward\n2. Attack\n3. Heal");
    }
}