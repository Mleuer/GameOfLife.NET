using System.IO;
using GameOfLife.NET.Model;
using SFML.Graphics;

namespace GameOfLife.NET.Config
{
    public static class Configuration
    {
        public const uint GameBoardWidth = 32;
        public const uint GameBoardHeight = 32;
        public const uint TileWidth = ResolutionWidth / GameBoardWidth;
        public const uint TileHeight = ResolutionHeight / GameBoardHeight;
        public const uint ResolutionWidth  = 896;
        public const uint ResolutionHeight = 896;
        public const uint Margin = 4;
        public static string DeadTileImagePath = "Assets/Bitmaps/DeadTileSmall.png";
        public static string LiveTileImagePath = "Assets/Bitmaps/LiveTileSmall.png";


        public static void LoadDefaultTileImages()
        {
            GraphicalTile.DeadTileTexture = new Texture(new Image(new FileStream(DeadTileImagePath, FileMode.Open)));
            GraphicalTile.LiveTileTexture = new Texture(new Image(new FileStream(LiveTileImagePath, FileMode.Open)));
        }
        
       
    }
}