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
        private bool newGamePending = false;
        private int currentLevel;
        private ShowTextState showTextState = new(2f);

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
            gameplayState.level = currentLevel;
            gameplayState.fieldHeight = screenHeight;
            gameplayState.fieldWidth = screenWidth;
            ChangeState(gameplayState);
            gameplayState.Reset();
        }
        private void GoToGameOver()
        {
            currentLevel = 0;
            newGamePending = true;
            showTextState.text = $"Game Over!";
            ChangeState(showTextState);
        }
        private void GoToNextLevel()
        {
            currentLevel++;
            newGamePending = false;
            showTextState.text = $"Level {currentLevel}";
            ChangeState(showTextState);
        }
        public override void Update(float deltaTime)
        {
            if(currentState != null && !currentState.IsDone())
                return;

            if (currentState == null || currentState == gameplayState && !gameplayState.gameOver)
                GoToNextLevel();

            else if (currentState == gameplayState && gameplayState.gameOver)
                GoToGameOver();

            else if (currentState != gameplayState && newGamePending)
                GoToNextLevel();

            else if (currentState != gameplayState && !newGamePending)
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
