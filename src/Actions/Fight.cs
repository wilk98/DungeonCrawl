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
        _fightArea.AddObject(player.Position, player);
        _fightArea.AddObject(monster.Position, monster);
        {
            UpdateAreaFight(player, monster);
            if (player.Position.Y - monster.Position.Y > 1)
            {
                bool condition = false;
                while (!condition)
                    {
                string options = Console.ReadLine();
                    switch (options)
                    {
                        case "1":
                            ChangePosition(player);
                            condition = true;
                            break;
                        case "2":
                            HealPlayer(player);
                            condition= true;
                            break;
                        default:
                            Console.WriteLine("Valid choice. Choose 1 or 2");
                            break;
                     }
                }
            }
            else
            {
                bool condition = false;
                while(!condition)
                {
                string options = Console.ReadLine();
                    switch (options)
                    {
                        case "1":
                            PlayerAttack(player, monster);
                            condition = true;
                            break;
                        case "2":
                            HealPlayer(player);
                            condition = true;
                            break;
                        default:
                            Console.WriteLine("Valid choice. Choose 1 or 2");
                            break;
                     }
                }
            }
        }
    }

    private void UpdateAreaFight(Player player, Monster monster)
    {
        Console.Clear();
        var view = _camera.GetView(_fightArea);
        var monsterInfo = _sidebarDirector;
        var inventoryView = _sidebarDirector.MakeInfobarFight(player.Stats, monster.Stats, view.Count());
        _display.DisplayView(view, inventoryView);
        _display.DisplayOptionsFight(player.Position.Y, monster.Position.Y);
    }

    public void ChangePosition(Player player)
    {
        int a= player.Position.Y - 1;
        var oldPlayerPosition = new Position(player.Position.X, player.Position.Y);
        var newPlayerPosition = new Position(player.Position.X, a);
        player.Position = newPlayerPosition;
        _fightArea.ChangePositions(newPlayerPosition, oldPlayerPosition);
    }
    public void HealPlayer(Player player)
    {

    }
    public void FightRound(Player player, Monster monster)
    {
        while (player.Stats.HealthPoints > 0 && monster.Stats.HealthPoints > 0)
        {
            PlayerTurn(player, monster);
            MonsterTurn(player, monster);
        }
    }
    public void PlayerAttack(Player player,Monster monster)
    {
        int attackPlayer = player.Stats.Strength;
        int defenceMonster = monster.Stats.Defense;
        monster.Stats.HealthPoints = monster.Stats.HealthPoints - (attackPlayer - defenceMonster);

    }
    public void MonsterTurn(Player player, Monster monster)
    {
        UpdateAreaFight(player, monster);
        if (monster is Archer)
        {
            int attackMonster = monster.Stats.Strength;
            int defencePlayer = player.Stats.Defense;
            player.Stats.HealthPoints = player.Stats.HealthPoints - (attackMonster - defencePlayer);
        }
        else if (monster is Warrior)
        {
            if(player.Position.Y - monster.Position.Y == 1)
            {
                int attackMonster = monster.Stats.Strength;
                int defencePlayer = player.Stats.Defense;
                player.Stats.HealthPoints = player.Stats.HealthPoints - (attackMonster - defencePlayer);
            }
        }
    }
}