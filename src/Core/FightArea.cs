using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Crawl.src.Objects.StaticObjects;

namespace Dungeon_Crawl.src.Core;

internal class FightArea
{
    private readonly GameObject[,] _field;
    private const int _width = 5;
    private const int _height = 10;

    public int Width => _width;

    public int Height => _height;
    public FightArea()
    {
        _field = new GameObject[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (x == 0 || x == Width-1 || y == 0 || y == Height-1)
                {
                    _field[x, y] = new Wall(new Position(x, y));
                }
                else
                {
                    _field[x, y] = new Air(new Position(x, y));
                }
            }
        }
    }
    public List<string> RenderAreaFight()
    {
        //Update();
        //Render();
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
    public GameObject At(Position position)
    {
        if (position.X < 0 || position.X >= Width)
            return new Wall(position);
        if (position.Y < 0 || position.Y >= Height)
            return new Wall(position);
        return _field[position.X, position.Y];
    }
}

