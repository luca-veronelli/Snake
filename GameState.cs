namespace Snake
{
    public class GameState
    {
        public int Rows { get; }
        public int Columns { get; }
        public GridValue[,] Grid { get; }
        public Direction Direction { get; private set; }
        public int Score { get; private set; }
        public bool GameOver {  get; private set; }

        private readonly LinkedList<Position> _snakePositions = new LinkedList<Position>();
        private readonly Random random = new Random();

        public GameState(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Grid = new GridValue[Rows, Columns];
            Direction = Direction.Right;

            AddSnake();
            AddFood();
        }

        private void AddSnake() 
        {
            int row = Rows / 2;

            for (int column = 1; column <= 3: c++)
            {
                Grid[row, column] = GridValue.Snake;
                _snakePositions.AddFirst(new Position(row, column));
            }
        }

        private IEnumerable<Position> EmptyPositions()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (Grid[row, column] == GridValue.Empty)
                    {
                        yield return new Position(row, column);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }

            Position position = empty[random.Next(empty.Count)];
            Grid[position.Row, position.Column] = GridValue.Food;
        }

        public Position HeadPosition()
        {
            return _snakePositions.First.Value;
        }

        public Position TailPosition()
        {
            return _snakePositions.Last.Value;
        }

        public IEnumerable<Position> SnakePositions()
        {
            return _snakePositions;
        }

        private void AddHead(Position position)
        {
            _snakePositions.AddFirst(position);
            Grid[position.Row, position.Column] = GridValue.Snake;
        }

        private void RemoveTail()
        {
            Position tail = _snakePositions.Last.Value;
            Grid[tail.Row, tail.Column] = GridValue.Empty;
            _snakePositions.RemoveLast();
        }


    }
}
