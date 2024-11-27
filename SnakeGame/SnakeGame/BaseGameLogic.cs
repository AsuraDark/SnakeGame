using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
        protected BaseGameState? currentState;
        protected float time;
        protected int screenWidth;
        protected int screenHeight;
        public void DrawNewState(float deltaTime, ConsoleRenderer renderer)
        {
            time += deltaTime;
            screenWidth = renderer.width;
            screenHeight = renderer.height;
            currentState?.Update(deltaTime);
            currentState?.Draw(renderer);
            Update(deltaTime);
        }
        protected void ChangeState(BaseGameState state)
        {
            currentState?.Reset();
            currentState = state;
        }
        public abstract ConsoleColor[] CreatePallet();

        public abstract void OnArrowDown();


        public abstract void OnArrowLeft();


        public abstract void OnArrowRight();


        public abstract void OnArrowUp();

        public void InitializeInput(ConsoleInput input)
        {
            input.Subscribe(this);
        }
        public abstract void Update(float deltaTime);

    }
}
