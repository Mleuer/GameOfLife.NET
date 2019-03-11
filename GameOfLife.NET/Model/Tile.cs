using System.IO;
using SFML.Graphics;
using SFML.System;
using static GameOfLife.NET.Config.Configuration;

namespace GameOfLife.NET.Model
{
    public class Tile
    {
        public TileState State { get; set; } = TileState.Dead;
        public TileState NextState { get; set; } = TileState.Unset;

        public void ChangeState()
        {
            if (this.State == TileState.Alive) 
            {
                this.State = TileState.Dead;
            }
            else if (this.State == TileState.Dead)  
            {
                this.State = TileState.Alive;
            }
        }
    }

    public class GraphicalTile : Tile, Drawable
    {
        public static Texture DeadTileTexture {get;} = new Texture(new Image(new FileStream("Assets/Bitmaps/DeadTileSmall.png", FileMode.Open)));
        public static Texture LiveTileTexture { get; } = new Texture(new Image(new FileStream("Assets/Bitmaps/LiveTileSmall.png", FileMode.Open)));

        public Sprite DeadTileSprite = new Sprite
        {
            Texture = DeadTileTexture
            
        };
        public Sprite LiveTileSprite = new Sprite
        {
            Texture = LiveTileTexture
        };

        public (uint, uint) Position
        {
            get
            {
                return ((uint)DeadTileSprite.Position.X, (uint)DeadTileSprite.Position.Y);
            }
            private set
            {
                Vector2f position = new Vector2f(value.Item1, value.Item2);
                DeadTileSprite.Position = position;
                LiveTileSprite.Position = position;
            }
        }
        
        public GraphicalTile((uint, uint) position)
        {
            
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (this.State == TileState.Dead) 
            {
                DeadTileSprite.Draw(target, states);
            }
            else if (this.State == TileState.Alive)  
            {
                LiveTileSprite.Draw(target, states);
            }
        }
    }

    public enum TileState
    {
        Alive,
        Dead,
        Unset
    }
}