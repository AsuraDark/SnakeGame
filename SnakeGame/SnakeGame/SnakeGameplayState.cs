using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum SnakeDir
    {
        Up, Down, Left, Right
    }
    public class SnakeGameplayState : BaseGameState
    {
        public bool hasWon;
        public bool gameOver;
        private const char circleSybol = '0';
        private Cell _apple = new Cell();
        public int fieldWidth;
        public int fieldHeight;
        public int level;
        private const char symbolSnake = '■';
        private Random _random = new Random();
        private struct Cell
        {
            public int x;
            public int y;
            public Cell(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        private List<Cell> _body = new();
        private SnakeDir currentDir = SnakeDir.Down;
        private float _timeToMove;
        public void SetDirection(SnakeDir dir)
        {
            currentDir = dir;
        }
        private Cell ShiftTo(Cell from, SnakeDir toDir)
        {
            switch (toDir)
            {
                case SnakeDir.Left:
                    return new Cell(from.x - 1, from.y);
                case SnakeDir.Right:
                    return new Cell(from.x + 1, from.y);
                case SnakeDir.Up:
                    return new Cell(from.x, from.y - 1);
                case SnakeDir.Down:
                    return new Cell(from.x, from.y + 1);

            }
            return from;
        }
        public override void Reset()
        {
            _body.Clear();
            int middleY = fieldHeight/2;
            int middleX = fieldWidth/2;
            gameOver = false;
            hasWon = false;
            currentDir = SnakeDir.Down;
            _body.Add(new(middleX + 3, middleY));
            _apple = new(middleX - 3, middleY);
            _timeToMove = 0f;
        }

        public override void Update(float deltatime)
        {
            _timeToMove -= deltatime;
            if (_timeToMove > 0f || gameOver)
                return;
            _timeToMove = 1f / (4f + level);
            var head = _body[0];
            Cell nextCell = ShiftTo(head, currentDir);
            if(nextCell.Equals(_apple))
            {
                _body.Insert(0, _apple);
                hasWon = _body.Count >= level + 3;
                GenerateApple();
                return;
            }
            if (nextCell.x < 0 || nextCell.y < 0 || nextCell.x >= fieldWidth || nextCell.y >= fieldHeight)
            {
                gameOver = true;
                return;
            }
            _body.RemoveAt(_body.Count - 1);
            _body.Insert(0, nextCell);
        }
        public override void Draw(ConsoleRenderer renderer)
        {
            renderer.DrawString($"Level: {level}", 3, 1, ConsoleColor.White);
            renderer.DrawString($"Score: {_body.Count - 1}", 3, 2, ConsoleColor.White);

            foreach (var cell in _body)
            {
                renderer.SetPixel(cell.x, cell.y, symbolSnake, 0);
            }
            renderer.SetPixel(_apple.x, _apple.y, circleSybol, 1);
    
        }
        public void GenerateApple()
        {
            Cell cell;
            cell.x = _random.Next(fieldWidth);
            cell.y = _random.Next(fieldHeight);

            if (_body[0].Equals(cell))
            {
                if (cell.y > fieldHeight / 2)
                    cell.y--;
                else
                    cell.y++;
            }
            _apple = cell;
        }

        public override bool IsDone()
        {
            return gameOver || hasWon;
        }
    }
}
