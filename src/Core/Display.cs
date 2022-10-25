namespace Dungeon_Crawl.src.Core
{
    internal class Display
    {
        internal void DisplayView(List<string> view)
        {
            foreach (var line in view)
            {
                Console.WriteLine(line);
            }
        }
    }
}