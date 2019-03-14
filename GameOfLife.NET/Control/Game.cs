using System;
using System.Threading;
using GameOfLife.NET.Model;
using GameOfLife.NET.View;

namespace GameOfLife.NET.Control
{
    public class Game
    {
        public GraphicalGameBoard Board = new GraphicalGameBoard();
        public MainWindow Window = new MainWindow();
        public bool Running = true;
        
        public void Play()
        {
            Board.SetTilesAliveAtRandom(200u);
            Window.Draw(Board);
            Thread.Sleep(TimeSpan.FromSeconds(3)); 
            
            while (Running)
            {                
                Window.Draw(Board);
                Board.UpdateState();
                Thread.Sleep(TimeSpan.FromMilliseconds(500)); 
            }
        }
    }
}