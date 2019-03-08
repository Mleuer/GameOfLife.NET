namespace GameOfLife.NET.Config
{
    public static class Configuration
    {
        public const uint GameBoardWidth = 64;
        public const uint GameBoardHeight = 64;
        public const uint TileWidth = ResolutionWidth / GameBoardWidth;
        public const uint TileHeight = ResolutionHeight / GameBoardHeight;
        public const uint ResolutionWidth  = 512;
        public const uint ResolutionHeight = 512;
        
       
    }
}