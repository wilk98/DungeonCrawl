using Dungeon_Crawl.src.Core;
using Dungeon_Crawl.src.Core.View;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Actions;

internal class Fight
{
    private readonly Camera _camera;
    private readonly SidebarDirector _sidebarDirector;
    private readonly Display _display;
    private FightArea _fightArea;
    private Player _player;
    private Monster _monster;
    public Position Position { get; set; }

    public Fight()
    {
        _fightArea = new FightArea();
        _camera = new Camera();
        _display = new Display();
        _sidebarDirector = new SidebarDirector();
    }

    public void PlayerTurn(Player player, Monster monster)
    {
        
        Console.WriteLine("dupa");
        Console.ReadLine();
        _fightArea.AddObject(player.Position, player);
        _fightArea.AddObject(monster.Position, monster);
        while (player.Stats.HealthPoints > 0)
        {
            Console.Clear();
            var view = _camera.GetView(_fightArea);
            var inventoryView = _sidebarDirector.MakeInfobar(player.Stats, player.Inventory, view.Count());
            _display.DisplayView(view, inventoryView);
            _display.DisplayOptionsFight(player.Position.Y, monster.Position.Y);
            if (player.Position.Y - monster.Position.Y > 1)
            {
                string options = Console.ReadLine();
                switch (options)
                {
                    case "1":
                        Console.WriteLine(player.Position.Y);
                        ChangePosition(player);
                        Console.ReadLine();
                        break;
                    case "2":
                        HealPlayer();
                        break;
                    default:
                        break;
                }
            }
        }

    }
    public void ChangePosition(Player player)
    {
        int a= player.Position.Y - 1;
        Console.WriteLine(a);
        var oldPlayerPosition = new Position(player.Position.X, player.Position.Y);
        Console.WriteLine(oldPlayerPosition);
        var newPlayerPosition = new Position(player.Position.X, a);
        Console.WriteLine(newPlayerPosition);
        player.Position = newPlayerPosition;
        _fightArea.ChangePositions(newPlayerPosition, oldPlayerPosition);
    }
    public void HealPlayer()
    {

    }
    public void FightRound(Player player, Monster monster)
    {
        PlayerTurn(player, monster);
        //var newPlayerPosition = new Position(_player.Position.X, newPlayerY);
        //_fightArea.ChangePositions(newPlayerPosition, _player.Position);
    }
}