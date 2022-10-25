using Dungeon_Crawl.src.Actions;
using Dungeon_Crawl.src.Objects.DynamicObjects.Player;

namespace Dungeon_Crawl.src.Core
{
    internal class Game
    {
        private Map _map;
        private readonly Camera _camera;
        private readonly Player _player;
        private readonly State _currentState;
        private readonly Display _display;
        private readonly Movement _movement;

        public Game()
        {
            _currentState = State.Game;
            _player = new Player(new Position(5, 5));
            _map = new Map();
            _map.AddObject(_player.Position, _player);
            _movement = new Movement(_map);
            _camera = new Camera();
            _display = new Display();
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
                Update();
            }
        }

        private void Update()
        {

        }

        private void ProcessInput()
        {
            char key = Console.ReadKey().KeyChar;
            _player.ProcessInput(key, _movement);
        }

        private void Render()
        {
            switch (_currentState)
            {
                case State.Game:
                    Console.Clear();
                    var view = _camera.GetView(_player.Position, _map);
                    _display.DisplayView(view);
                    break;
                case State.Pause:
                    break;
                case State.Inventory:
                    break;
                case State.Fight:
                    break;
                default:
                    break;
            }
        }
    }
}
