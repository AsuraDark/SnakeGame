using System;
using System.Collections.Generic;
using System.Linq;
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
        public int fieldWidth;
        public int fieldHeight;
        public const char symbolSnake = '■';
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
            currentDir = SnakeDir.Down;
            _body.Add(new Cell(middleX, middleY));
            _timeToMove = 0f;
        }

        public override void Update(float deltatime)
        {
            _timeToMove -= deltatime;
            if (_timeToMove > 0f)
                return;
            _timeToMove = 1f / 5;
            var head = _body[0];
            Cell nextCell = ShiftTo(head, currentDir);
            _body.RemoveAt(_body.Count - 1);
            _body.Insert(0, nextCell);
        }
        public override void Draw(ConsoleRenderer renderer)
        {
            foreach (var cell in _body)
            {
                renderer.SetPixel(cell.x, cell.y, symbolSnake, 0);
            }
    
        }
    }
}
