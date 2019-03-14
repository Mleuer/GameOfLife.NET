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
            newGame.Play();
        }
    }
}