using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Core;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Player : DynamicObject
{
    private KeyboardController _keyboardController = new();
    public Player(Position position) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 100;
        Stats.Strength = 15;
        Stats.Defense = 5;

        Inventory = new Inventory();
    }

    protected override string Symbol { get => "P"; set => throw new NotImplementedException(); }
    public Inventory Inventory { get; internal set; }
    public Stats Stats { get; internal set; }

    public State ProcessInput(char key, Movement movementController)
    {
        switch (key)
        {
            case 'w':
            case 'a':
            case 's':
            case 'd':
                MakeMove(key, movementController);
                return State.Game;
            case 'i':
                return State.Inventory;
            default:
                return State.Game;
        }
    }

    private void MakeMove(char key, Movement movementController)
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

