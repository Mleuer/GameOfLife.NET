using System.IO;
using SFML.Graphics;
using SFML.System;
using static GameOfLife.NET.Config.Configuration;

namespace GameOfLife.NET.Model
{
    public class Tile : Drawable
    {
        public TileState State { get; set; } = TileState.Dead;
        public TileState NextState { get; set; } = TileState.Unset;

        public Sprite DeadTileSprite = new Sprite
        {
            Texture = new Texture(new Image(new FileStream("Assets/Bitmaps/DeadTileSmall.png", FileMode.Open)))
        };
        public Sprite LiveTileSprite = new Sprite
        {
            Texture = new Texture(new Image(new FileStream("Assets/Bitmaps/LiveTileSmall.png", FileMode.Open)))
        };
        

      
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