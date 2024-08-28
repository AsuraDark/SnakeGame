using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public abstract class BaseGameLogic : ConsoleInput.IArrowListener
    {
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
