using System.Collections.Generic;

namespace GameOfLife.NET.Model
{
    public class Tile
    {
        public TileState State { get; set; } = TileState.dead;
        public TileState NextState { get; set; } = TileState.tileStateUnset;

      
        public void ChangeState()
        {
            if (this.State == TileState.alive)
            {
                this.State = TileState.dead;
            }
            if (this.State == TileState.dead)
            {
                this.State = TileState.alive;
            }
        }

        public void CheckStateOfNeighbors()
        {
            
        }
        


    }

    public enum TileState
    {
        alive,
        dead,
        tileStateUnset
    }
}