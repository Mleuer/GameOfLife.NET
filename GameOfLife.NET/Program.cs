using GameOfLife.NET.Config;
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
            Configuration.LoadDefaultTileImages();
            BoardWindow boardWindow = new BoardWindow();
            boardWindow.Board.Grid[10][15].ChangeState();
            
            
            while (running)
            {
                boardWindow.Draw();
            }
            
        }
    }
}