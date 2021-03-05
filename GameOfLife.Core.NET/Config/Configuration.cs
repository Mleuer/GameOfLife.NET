using SFML.Graphics;

namespace GameOfLife.Core.NET.Config
{
    public static class Configuration
    {
        public const uint GameBoardWidth   = 32;
        public const uint GameBoardHeight  = 32;
        public const uint ResolutionWidth  = 896;
        public const uint ResolutionHeight = 896;
        public const uint Margin           = 4;

        public static Texture DefaultDeadTileTexture;
        public static Texture DefaultLiveTileTexture;

        static Configuration()
        {
	        DefaultDeadTileTexture = new Texture(new Image(Properties.Resources.DeadTileSmall));
	        DefaultLiveTileTexture = new Texture(new Image(Properties.Resources.LiveTileSmall));
        }

        public static uint ComputeTileWidth(uint gameBoardWidth)
        { 
	        return ResolutionWidth / gameBoardWidth;
        }

        public static uint ComputeTileHeight(uint gameBoardHeight)
        {
	        return ResolutionHeight / gameBoardHeight;
        }
    }
}