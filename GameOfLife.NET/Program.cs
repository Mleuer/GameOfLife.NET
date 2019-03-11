﻿using GameOfLife.NET.View;
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
            boardWindow.Board.Grid[1][5].ChangeState();
            boardWindow.Board.Grid[50][14].ChangeState();
            boardWindow.Board.Grid[29][40].ChangeState();
            
            while (running)
            {
                boardWindow.Draw();
            }
            
        }
    }
}