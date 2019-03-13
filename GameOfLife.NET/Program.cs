using GameOfLife.NET.Config;
using GameOfLife.NET.Control;
using GameOfLife.NET.Model;
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
            var newGame = new Game();
            newGame.Board.Grid[12][15].ChangeState();
            newGame.Board.Grid[12][16].ChangeState();
            newGame.Board.Grid[12][17].ChangeState();
            newGame.Board.Grid[12][18].ChangeState();
            newGame.Board.Grid[12][19].ChangeState();
            newGame.Board.Grid[12][20].ChangeState();
            newGame.Board.Grid[12][21].ChangeState();
            newGame.Board.Grid[12][22].ChangeState();
            newGame.Board.Grid[11][9].ChangeState();
            newGame.Board.Grid[11][10].ChangeState();
            newGame.Board.Grid[11][11].ChangeState();
            newGame.Board.Grid[11][12].ChangeState();
            newGame.Board.Grid[11][13].ChangeState();
            newGame.Board.Grid[11][14].ChangeState();
            newGame.Board.Grid[11][15].ChangeState();
            newGame.Board.Grid[11][16].ChangeState();
            newGame.Board.Grid[11][17].ChangeState();
            newGame.Board.Grid[11][18].ChangeState();
            newGame.Board.Grid[11][19].ChangeState();
            newGame.Board.Grid[13][16].ChangeState();
            newGame.Board.Grid[13][17].ChangeState();
            newGame.Board.Grid[13][18].ChangeState();
            newGame.Board.Grid[13][19].ChangeState();
            newGame.Board.Grid[13][20].ChangeState();
            newGame.Board.Grid[13][21].ChangeState();
            newGame.Board.Grid[13][22].ChangeState();
            newGame.Board.Grid[13][23].ChangeState();
            newGame.Play();
        }
    }
}