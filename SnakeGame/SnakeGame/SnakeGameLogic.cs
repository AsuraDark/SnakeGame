using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SnakeGame
{
    public class SnakeGameLogic : BaseGameLogic
    {
        SnakeGameplayState gameplayState = new SnakeGameplayState();
        
        public override void OnArrowDown()
        {
            if (currentState != gameplayState)
                return;
            gameplayState.SetDirection(SnakeDir.Down);
        }

        public override void OnArrowLeft()
        {
            if (currentState != gameplayState)
                return;
            gameplayState.SetDirection(SnakeDir.Left);
        }

        public override void OnArrowRight()
        {
            if (currentState != gameplayState)
                return;
            gameplayState.SetDirection(SnakeDir.Right);
        }

        public override void OnArrowUp()
        {
            if (currentState != gameplayState)
                return;
            gameplayState.SetDirection(SnakeDir.Up);
        }
        public void GotoGameplay()
        {
            gameplayState.fieldHeight = screenHeight;
            gameplayState.fieldWidth = screenWidth;
            ChangeState(gameplayState);
            gameplayState.Reset();
        }

        public override void Update(float deltaTime)
        {
            if(currentState != gameplayState)
                GotoGameplay();
        }

        public override ConsoleColor[] CreatePallet()
        {
            return
            [
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.White,
                ConsoleColor.Blue,
            ];
        }
    }
}
