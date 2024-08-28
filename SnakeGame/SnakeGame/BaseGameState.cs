using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    abstract public class BaseGameState
    {
        public abstract void Update(float deltatime);
        public abstract void Reset();
    }
}
