namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player;

internal class Player : DynamicObject
{
    private readonly KeyboardController _keyboardController = new();
    private readonly Movement movementController;
    private readonly Map map;
    private readonly ItemController itemController;
    private readonly NPCdialog NPCdialog;

    public Player(Position position, Movement movementController, Map map) : base(position)
    {
        Stats = new Stats();
        Stats.HealthPoints = 100;
        Stats.Strength = 15;
        Stats.Defense = 5;

        Inventory = new Inventory();
        this.movementController = movementController;
        this.map = map;
        itemController = new(map, this);
        NPCdialog = new(map, this);
    }

    protected override string Symbol { get => "P"; set => throw new NotImplementedException(); }
    public Inventory Inventory { get; internal set; }
    public Stats Stats { get; internal set; }
    public AskDialog? Info { get; internal set; }

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
                        if (itemController.PickItem() is State.Info) return State.Info;
                        if (NPCdialog.PickItem() is State.Info) return State.Info;
                        MakeMove(key, movementController);
                        return State.Game;
                    case ConsoleKey.I:
                        return State.Inventory;
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

}

