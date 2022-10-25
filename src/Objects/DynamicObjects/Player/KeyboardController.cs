namespace Dungeon_Crawl.src.Objects.DynamicObjects.Player
{
    internal class KeyboardController
    {
        public KeyboardController()
        {
        }
        public Position HandleMovement(char key, Position currentPosition)
        {
            var direction = GetDirection(key);
            var newPosition = MoveTowards(direction, currentPosition);
            var isValidMove = IsValidMove(newPosition);
            if (isValidMove)
                return newPosition;

            return currentPosition;
        }
        private bool IsValidMove(Position newPosition)
        {
            throw new NotImplementedException();
        }

        private Position MoveTowards(Direction directionTo, Position position)
        {
            var newPosition = directionTo switch
            {
                Direction.North => new Position(position.X, position.Y - 1),
                Direction.East => new Position(position.X + 1, position.Y),
                Direction.South => new Position(position.X, position.Y + 1),
                Direction.West => new Position(position.X - 1, position.Y),
                _ => throw new NotImplementedException(),
            };
            return newPosition;
        }

        private Direction GetDirection(char key)
        {
            return key switch
            {
                'w' => Direction.North,
                'a' => Direction.West,
                's' => Direction.South,
                'd' => Direction.East,
                _ => throw new NotImplementedException($"This key has no assigned direction: {key}"),
            };
        }
    }
}