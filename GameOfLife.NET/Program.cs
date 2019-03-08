using SFML.Graphics;
using SFML.Window;

namespace GameOfLife.NET
{
    internal class Program
    {
        public static void Main()
        {
            bool running = true;
            SFML.Window.VideoMode videoMode = new VideoMode(512, 512);
            SFML.Graphics.RenderWindow window = new RenderWindow(videoMode, "window");
            
            while (running)
            {
                window.DispatchEvents();
                window.Clear();
            }
            
        }
    }
}