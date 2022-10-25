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

        public Game()
        {
            _currentState = State.Game;
            _player = new Player(new Position(5, 5));
            _map = new Map();
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
            }
        }

        private void Update()
        {

        }

        private void ProcessInput()
        {
            char key = Console.ReadKey().KeyChar;
            _currentState = _player.ProcessInput(key, _movement);
        }

        private void Render()
        {
            Console.Clear();
            switch (_currentState)
            {
                case State.Game:
                case State.Inventory:
                    var view = _camera.GetView(_player.Position, _map);
                    var inventoryView = _sidebarDirector.MakeInfobar(_player.Stats, _player.Inventory, view.Count());
                    _display.DisplayView(view, inventoryView);
                    break;
                case State.Pause:
                    break;
                case State.Fight:
                    break;
                case State.Info:
                    break;
                default:
                    break;
            }
        }
    }
}
