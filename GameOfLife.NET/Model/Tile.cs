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
            if (this.State == TileState.Dead)  
            {
                this.State = TileState.Alive;
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