namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Player : DynamicObject, IControlable, IMovable
{
    private KeyboardController _keyboardController = new();
    public Player(Position position) : base(position)
    {
    }

    protected override string Symbol { get => "P"; set => throw new NotImplementedException(); }

    public void ProcessInput(char key)
    {
        var newPosition = _keyboardController.HandleMovement(key, _position);
    }


    public override string Render()
    {
        return Symbol;
    }

    public override void Update()
    {

    }

    public void Move()
    {
        throw new NotImplementedException();
    }
}

