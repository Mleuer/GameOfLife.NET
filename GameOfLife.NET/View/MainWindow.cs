using System;
using System.Threading;
using GameOfLife.NET.Model;
using SFML.Graphics;
using SFML.Window;

namespace GameOfLife.NET.View
{
    public class MainWindow
    {
        public RenderWindow Window = new RenderWindow(new VideoMode(Config.Configuration.ResolutionWidth, Config.Configuration.ResolutionHeight) , "Game of Life");        
        public void Draw(Drawable output)
        {
            Window.Clear();
            output.Draw(Window, RenderStates.Default);
            Window.Display();
            Window.DispatchEvents();
        }
        
    }
}