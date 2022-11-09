﻿namespace Dungeon_Crawl.src.Core;
internal class Map
{
    private GameObject[,] _field;
    private const int _width = 151;
    private const int _height = 67;
    private int currentFloor = 0;

    public int CurrentFloor
    {
        get => currentFloor;
        set => currentFloor = value;
    }
    public int Width => _width;

    public int Height => _height;

    public Map()
    {
        if (currentFloor == 0)
        {
            FirstMap();
        }
        else
        {
            SecondMap();
        }
    }

    private void FirstMap()
    {
        _field = new GameObject[Width, Height];
        var firstMap = ReadMap.ReadFirstFloor();
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (firstMap[i][j] == '#')
                {
                    _field[j, i] = new Wall(new Position(j, i));
                }
                else if (firstMap[i][j] == ' ')
                {
                    _field[j, i] = new Air(new Position(j, i));
                }
                else if (firstMap[i][j] == 'I')
                {
                    var items = new ItemList(new Position(j, i), this);
                    _field[j, i] = items.RandomItem();
                }
                else if (firstMap[i][j] == 'r')
                {
                    _field[j, i] = new Key(new Position(j, i), "Red", this);
                }
                else if (firstMap[i][j] == 'g')
                {
                    _field[j, i] = new Key(new Position(j, i), "Green", this);
                }
                else if (firstMap[i][j] == 'R')
                {
                    _field[j, i] = new Door(new Position(j, i), "Red");
                    currentFloor += 1;
                }
                else if (firstMap[i][j] == 'G')
                {
                    _field[j, i] = new Door(new Position(j, i), "Green");
                }
                else if (firstMap[i][j] == 'N')
                {
                    _field[j, i] = new NPC(new Position(j, i));
                }
                else if (firstMap[i][j] == 'M')
                {
                    var monsters = new MonsterList(new Position(j, i));
                    _field[j, i] = monsters.RandomMonster();
                }
                else
                    _field[j, i] = new Wall(new Position(j, i));
            }
        }
    }
    private void SecondMap()
    {
        _field = new GameObject[Width, Height];
        var firstMap = ReadMap.ReadSecondFloor();
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (firstMap[i][j] == '#')
                {
                    _field[j, i] = new Wall(new Position(j, i));
                }
                else if (firstMap[i][j] == ' ')
                {
                    _field[j, i] = new Air(new Position(j, i));
                }
                else if (firstMap[i][j] == 'I')
                {
                    var items = new ItemList(new Position(j, i), this);
                    _field[j, i] = items.RandomItem();
                }
                else if (firstMap[i][j] == 'r')
                {
                    _field[j, i] = new Key(new Position(j, i), "Red", this);
                }
                else if (firstMap[i][j] == 'g')
                {
                    _field[j, i] = new Key(new Position(j, i), "Green", this);
                }
                else if (firstMap[i][j] == 'R')
                {
                    _field[j, i] = new Door(new Position(j, i), "Red");
                }
                else if (firstMap[i][j] == 'G')
                {
                    _field[j, i] = new Door(new Position(j, i), "Green");
                }
                else if (firstMap[i][j] == 'N')
                {
                    _field[j, i] = new NPC(new Position(j, i));
                }
                else if (firstMap[i][j] == 'M')
                {
                    var monsters = new MonsterList(new Position(j, i));
                    _field[j, i] = monsters.RandomMonster();
                }
                else
                    _field[j, i] = new Wall(new Position(j, i));
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

    public void AddObject(Position position, GameObject gameObject)
    {
        _field[position.X, position.Y] = gameObject;
    }

    public GameObject At(Position position)
    {
        if (position.X < 0 || position.X >= Width)
            return new Wall(position);
        if (position.Y < 0 || position.Y >= Height)
            return new Wall(position);
        return _field[position.X, position.Y];
    }
    public void ChangePositions(Position pos1, Position pos2)
    {
        var oldPosition = At(pos1);
        var newPosition = At(pos2);

        _field[pos1.X, pos1.Y] = newPosition;
        _field[pos2.X, pos2.Y] = oldPosition;
    }

    internal void DeleteAt(Position position)
    {
        _field[position.X, position.Y] = new Air(position);
    }
    internal string SearchMonster(int x, int y)
    {
        if (_field[x - 1, y] is Monster)
        {

            return _field[x - 1, y].ToString();
        }
        else if (_field[x + 1, y] is Monster)
        {
            return _field[x + 1, y].ToString();
        }
        else if (_field[x, y + 1] is Monster)
        {
            return _field[x, y + 1].ToString();
        }
        else if (_field[x, y - 1] is Monster)
        {
            return _field[x, y -1].ToString();
        }
        return null;
    }
    internal void DeleteMonster(Position position)
    {
        if (_field[position.X - 1, position.Y] is Monster)
        {
            _field[position.X-1, position.Y] = new Air(new Position(position.X - 1, position.Y));
        }
        else if (_field[position.X + 1, position.Y] is Monster)
        {
            _field[position.X + 1, position.Y] = new Air(new Position(position.X + 1, position.Y));
        }
        else if (_field[position.X, position.Y - 1] is Monster)
        {
            _field[position.X, position.Y - 1] = new Air(new Position(position.X, position.Y -1));
        }
        else if (_field[position.X, position.Y +1] is Monster)
        {
            _field[position.X, position.Y + 1] = new Air(new Position(position.X , position.Y+1));
        }
    }
}
