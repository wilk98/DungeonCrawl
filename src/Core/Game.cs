using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Core.View;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Core
{
    internal class Game
    {
        private Map _map;
        private readonly Camera _camera;
        private readonly Player _player;
        private readonly Display _display;
        private readonly Movement _movement;
        private readonly SidebarDirector _sidebarDirector;
        private State _currentState;
        private Info? _pendingInfo;

        public Game()
        {
            _currentState = State.Game;
            _map = new Map();
            _player = new Player(new Position(5, 5), new Movement(_map), _map);
            _map.AddObject(_player.Position, _player);
            _movement = new Movement(_map);
            _camera = new Camera();
            _display = new Display();
            _sidebarDirector = new SidebarDirector();
        }
        public void Start()
        {
            Gameloop();
        }
        private void Gameloop()
        {
            while (true)
            {
                Render();
                ProcessInput();
                if (_currentState == State.Game)
                    Update();
                if (_currentState == State.Info)
                {
                    _pendingInfo = _player.Info;
                }
            }
        }

        private void Update()
        {
            
        }

        private void ProcessInput()
        {
            var key = Console.ReadKey().Key;
            _currentState = _player.ProcessInput(key, _currentState);
        }

        private void Render()
        {
            Console.Clear();
            switch (_currentState)
            {
                case State.Game:
                case State.Inventory:
                    {
                        var view = _camera.GetView(_player.Position, _map);
                        var inventoryView = _sidebarDirector.MakeInfobar(_player.Stats, _player.Inventory, view.Count());
                        _display.DisplayView(view, inventoryView);
                    }
                    break;
                case State.Pause:
                    break;
                case State.Fight:
                    break;
                case State.Info:
                    {
                        if (_pendingInfo is null)
                        {
                            throw new Exception("Info should not be null");
                        }
                        var view = _camera.GetView(_player.Position, _map);
                        var inventoryView = _sidebarDirector.MakeInfobar(_player.Stats, _player.Inventory, view.Count());
                        var infoBox = _sidebarDirector.MakeInfoBox(_pendingInfo);
                        _display.DisplayInfo(view, inventoryView, infoBox);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
