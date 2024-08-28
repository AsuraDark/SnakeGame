using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ConsoleInput
    {
        public interface IArrowListener
        {
            public abstract void OnArrowUp();
            public abstract void OnArrowDown();
            public abstract void OnArrowLeft();
            public abstract void OnArrowRight();

        }
        private HashSet<IArrowListener> arrowListeners = new HashSet<IArrowListener>();
        public void Subscribe(IArrowListener listener)
        {
            arrowListeners.Add(listener);
        }
        public void Update()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach(var listener in arrowListeners)
                            listener.OnArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var listener in arrowListeners)
                            listener.OnArrowDown();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var listener in arrowListeners)
                            listener.OnArrowLeft();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var listener in arrowListeners)
                            listener.OnArrowRight();
                        break;
                }
            }
        }
    }
}
