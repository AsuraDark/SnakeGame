﻿using SnakeGame;

public class Program
{
    const float targetFrameTime = 1f / 60;
    static void Main()
    {
        var gameLogic = new SnakeGameLogic();
        var pallete = gameLogic.CreatePallet();
        var renderer0 = new ConsoleRenderer(pallete);
        var renderer1 = new ConsoleRenderer(pallete);
        var input = new ConsoleInput();
        gameLogic.InitializeInput(input);
        var prevRenderer = renderer0;
        var currRenderer = renderer1;
        var lastFrameTime = DateTime.Now;
        while (true)
        {
            var frameStartTime = DateTime.Now;
            float deltaTime = (float) (frameStartTime - lastFrameTime).TotalSeconds;
            input.Update();
            gameLogic.DrawNewState(deltaTime, currRenderer);
            lastFrameTime = frameStartTime;
            if (currRenderer != prevRenderer)
                currRenderer.Render();
            var tmp = prevRenderer;
            prevRenderer = currRenderer;
            currRenderer = tmp;
            currRenderer.Clear();
            var nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targetFrameTime);
            var endFrameTime = DateTime.Now;
            if (nextFrameTime > endFrameTime)
            {
                Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
            }
        }
    }
}