using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawl.src.Objects;
using Dungeon_Crawl.src.Objects.StaticObjects;

namespace Dungeon_Crawl.src.Core;

internal class FightArea
{
    private readonly GameObject[,] _field;
    private const int _width = 13;
    private const int _height = 9;

    public int Width => _width;

    public int Height => _height;
    public FightArea()
    {
        _field = new GameObject[Height, Width];
        var areaFight = ReadMap.ReadAreaFight();
        for (int x = 0; x < Height; x++)
        {
            for (int y = 0; y < Width; y++)
            {
                if (areaFight[x][y]== '#')
                {
                    _field[x, y] = new Wall(new Position(x, y));
                }
                else if (areaFight[x][y]== ' ')
                {
                    _field[x, y] = new Air(new Position(x, y));
                }
            }
        }
    }
    public List<string> RenderAreaFight()
    {
        Update();
        Render();
        var map = new List<string>();
        for (int y = 0; y < Width; y++)
        {
            var row = new string[Height];
            for (int x = 0; x < Height; x++)
            {
                row[x] = At(new Position(x, y)).ToString();
            }
            map.Add(string.Join("", row));
        }
        return map;
    }
    public GameObject At(Position position)
    {
        if (position.Y < 0 || position.Y >= Width)
            return new Wall(position);
        if (position.X < 0 || position.X >= Height)
            return new Wall(position);
        return _field[position.X, position.Y];
    }
    public void Update()
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
    public void AddObject(Position position, GameObject gameObject)
    {
        _field[position.X, position.Y] = gameObject;
    }
    public void ChangePositions(Position pos1, Position pos2)
    {
        var oldPosition = At(pos1);
        var newPosition = At(pos2);

        _field[pos1.X, pos1.Y] = newPosition;
        _field[pos2.X, pos2.Y] = oldPosition;
    }
    public void DeletePositions(Position pos)
    {
        _field[pos.X, pos.Y] = new Air(pos);
    }
}

