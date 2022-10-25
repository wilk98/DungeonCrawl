namespace Dungeon_Crawl.src.Core;
internal class Map
{
    private readonly GameObject[,] _field;
    private const int _width = 243;
    private const int _height = 75;

    public int Width => _width;

    public int Height => _height;

    public Map()
    {
        _field = new GameObject[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
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
        for (int y = 0; y < Height; y++)
        {
            var row = new string[Width];
            for (int x = 0; x < Width; x++)
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
        if (position.X < 0 || position.X > Width)
            throw new ArgumentOutOfRangeException();
        if (position.Y < 0 || position.Y > Height)
            throw new ArgumentOutOfRangeException();
        return _field[position.X, position.Y];
    }
    public void ChangePositions(Position pos1, Position pos2)
    {
        var oldPosition = At(pos1);
        var newPosition = At(pos2);

        _field[pos1.X, pos1.Y] = newPosition;
        _field[pos2.X, pos2.Y] = oldPosition;
    }
}
