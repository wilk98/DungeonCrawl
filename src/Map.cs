using Dungeon_Crawl.src.Objects.StaticObjects;

namespace Dungeon_Crawl.src;
internal class Map
{
    private readonly GameObject[,] _field;
    private const int _width = 243;
    private const int _height = 75;

    public Map()
    {
        _field = new GameObject[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _field[x, y] = new Wall(new Position(x, y));
            }
        }
    }

    public List<string> RenderMap()
    {
        Update();
        Render();
        var map = new List<string>();
        for (int y = 0; y < _height; y++)
        {
            var row = new string[_width];
            for (int x = 0; x < _width; x++)
            {
                row[x] = At(new Position(x, y)).ToString();
            }
            map.Add(string.Join("", row));
        }
        return map;
    }

    private void Update()
    {
        foreach (var gameObject in _field)
        {
            gameObject.Update();
        }
    }

    private void Render()
    {
        foreach (var gameObject in _field)
        {
            gameObject.Render();
        }
    }

    public GameObject At(Position position)
    {
        if (position.X < 0 || position.X > _width)
            throw new ArgumentOutOfRangeException();
        if (position.Y < 0 || position.Y > _height)
            throw new ArgumentOutOfRangeException();
        return _field[position.X, position.Y];
    }
}
