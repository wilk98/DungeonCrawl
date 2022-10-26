namespace Dungeon_Crawl.src.Maps;
internal class ReadMap
    {
        private static GameObject[,] _field;
        private static int _width = 151;
        private static int _height = 67;
        private static int count = 0;
        public static int Width => _width;

        public static int Height => _height;
    public static void ReadFirstMapFile()
        {
            _field = new GameObject[Width, Height];
            var firstMap = File.ReadAllLines(@"..\..\..\src\Maps\map1.txt");
            for (int i = 0; i < firstMap.Length; i++)
            {
                for (int j = 0; j < firstMap[i].Length; j++)
                {
                    _field[i,j] = firstMap[i][j];
                }
            }   
        }
        }
    

