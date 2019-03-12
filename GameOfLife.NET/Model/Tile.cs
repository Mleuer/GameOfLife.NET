using System.IO;
using SFML.Graphics;
using SFML.System;
using static GameOfLife.NET.Config.Configuration;

namespace GameOfLife.NET.Model
{
    public class Tile
    {
        private TileState state = TileState.Dead;

        public virtual TileState State
        {
            get { return state; }
            set { state = value; }
        }

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
        public override TileState State
        {
            get { return base.State;}
            set
            {
                base.State = value; 

                if (State == TileState.Dead)
                {
                    TileSprite.Texture = DeadTileTexture;
                }
                else if (State == TileState.Alive)
                {
                    TileSprite.Texture = LiveTileTexture;
                }
            }
        }
        public static Texture DeadTileTexture {get; set; }
        public static Texture LiveTileTexture { get; set; }

        public Sprite TileSprite = new Sprite
        {
            Texture = DeadTileTexture
        };
        

        public (uint, uint) Position
        {
            get
            {
                return ((uint)TileSprite.Position.X, (uint)TileSprite.Position.Y);
            }
            private set
            {
                Vector2f position = new Vector2f(value.Item1, value.Item2);
                TileSprite.Position = position;
            }
        }
        
        public GraphicalTile((uint, uint) position)
        {
            Position = position;
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            TileSprite.Draw(target, states);
            
        }
    }

    public enum TileState
    {
        Alive,
        Dead,
        Unset
    }
}