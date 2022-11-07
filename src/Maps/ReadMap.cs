namespace Dungeon_Crawl.src.Maps;
internal class ReadMap
{

    public static string[] ReadFirstMapFile()
        {
            var firstMap = File.ReadAllLines(@"..\..\..\src\Maps\map\map1.txt");
            return firstMap;
        }
    public static string[] ReadAreaFight()
    {
        var areaFight = File.ReadAllLines(@"..\..\..\src\Maps\map\areafight.txt");
        return areaFight;
    }
}
    

