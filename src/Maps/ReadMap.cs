namespace Dungeon_Crawl.src.Maps;
internal class ReadMap
    {

    public static string[] ReadFirstMapFile()
        {
            var firstMap = File.ReadAllLines(@"..\..\..\src\Maps\map1.txt");
            return firstMap;
        }
    }
    

