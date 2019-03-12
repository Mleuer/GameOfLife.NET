using System;
using System.Threading;
using GameOfLife.NET.Model;
using SFML.Graphics;
using SFML.Window;

namespace GameOfLife.NET.View
{
    public class BoardWindow
    {
        public RenderWindow Window = new RenderWindow(new VideoMode(Config.Configuration.ResolutionWidth, Config.Configuration.ResolutionHeight) , "Game of Life");
        public GraphicalGameBoard Board = new GraphicalGameBoard();
        
        public void Draw()
        {
            Window.DispatchEvents();
            Window.Clear();
            Board.Draw(Window, RenderStates.Default);
            Thread.Sleep(TimeSpan.FromMilliseconds(16)); 
        }
        
    }
}