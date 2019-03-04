namespace GameOfLife.NET.Model
{
    public class Tile
    {
        public TileState State { get; set; }

        
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
        dead
    }
}