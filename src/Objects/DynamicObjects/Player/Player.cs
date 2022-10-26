using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Core;

namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Player : DynamicObject
{
    private KeyboardController _keyboardController = new();
    private Movement movementController;

    public Player(Position position, Movement movementController) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 100;
        Stats.Strength = 15;
        Stats.Defense = 5;

        Inventory = new Inventory();
        this.movementController = movementController;
    }

    protected override string Symbol { get => "P"; set => throw new NotImplementedException(); }
    public Inventory Inventory { get; internal set; }
    public Stats Stats { get; internal set; }
    public Info? Info { get; internal set; }

    public State ProcessInput(ConsoleKey key, State currentState)
    {
        switch (currentState)
        {
            case State.Game:
                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.S:
                    case ConsoleKey.A:
                    case ConsoleKey.D:
                        MakeMove(key, movementController);
                        return State.Game;
                    case ConsoleKey.I:
                        return State.Inventory;
                    case ConsoleKey.F:
                        Info = new Info("Test info!", new Tuple<string, string>("Yes", "No"), HandleInfo);
                        return State.Info;
                    default:
                        return State.Game;
                }
            case State.Pause:
                break;
            case State.Inventory:
                switch (key)
                {
                    case ConsoleKey.W:
                        Inventory.PreviousSelected();
                        return State.Inventory;
                    case ConsoleKey.S:
                        Inventory.NextSelected();
                        return State.Inventory;
                    default:
                        return State.Game;
                }
            case State.Info:
                if (Info is null)
                    return State.Game;
                switch (key)
                {
                    case ConsoleKey.D:
                        Info.SelectRight();
                        return State.Info;
                    case ConsoleKey.A:
                        Info.SelectLeft();
                        return State.Info;
                    case ConsoleKey.Enter:
                        Info.Select();
                        return State.Game;
                    default:
                        return State.Game;
                }
            case State.Fight:
                break;
        }
        return State.Game;
    }

    private void MakeMove(ConsoleKey key, Movement movementController)
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

    internal void HandleInfo(bool accepted)
    {
        Stats.HealthPoints -= 50;
    }
}

