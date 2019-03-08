using GameOfLife.NET.View;
using SFML.Graphics;
using SFML.Window;

namespace GameOfLife.NET
{
    internal class Program
    {
        public static void Main()
        {
            var running = true;
            BoardWindow boardWindow = new BoardWindow();
            
            while (running)
            {
                boardWindow.Draw();
            }
            
        }
    }
}