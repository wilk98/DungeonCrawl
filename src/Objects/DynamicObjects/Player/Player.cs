using Dungeon_Crawl.src.Actions;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Player : DynamicObject
{
    private KeyboardController _keyboardController = new();
    public Player(Position position) : base(position)
    {
    }

    protected override string Symbol { get => "P"; set => throw new NotImplementedException(); }

    public void ProcessInput(char key, Movement movementController)
    {
        var newPosition = KeyboardController.HandleMovement(key, Position);
        var MoveWasSuccessfull = movementController.Move(Position, newPosition);
        if (MoveWasSuccessfull)
        {
            Position = newPosition;
        }
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

