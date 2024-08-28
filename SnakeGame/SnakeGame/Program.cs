﻿using SnakeGame;

public class Program
{
    static void Main()
    {
        var gameLogic = new SnakeGameLogic();
        var input = new ConsoleInput();
        gameLogic.InitializeInput(input);
        var lastFrameTime = DateTime.Now;
        gameLogic.GotoGameplay();
        while (true)
        {
            input.Update();
            var frameStartTime = DateTime.Now;
            float deltaTime = (float) (frameStartTime - lastFrameTime).TotalSeconds;
            gameLogic.Update(deltaTime);
            lastFrameTime = frameStartTime;
        }
    }
}