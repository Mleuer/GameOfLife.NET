using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace GameOfLife.NET.Model


{
    public class GameBoard : Drawable
    {
        public Tile[][] Grid { get; }

        public GameBoard(Tile[][] grid)
        {
            Grid = grid;
        }

        public GameBoard()
        {
            Grid = new Tile[Config.Configuration.GameBoardWidth][];
            for (int i = 0; i < Config.Configuration.GameBoardWidth; i++)
            {
                Tile[] tiles = Grid[i];
                tiles = new Tile[Config.Configuration.GameBoardHeight];
                
                for (int j = 0; j < Config.Configuration.GameBoardHeight; j++)
                {
                    tiles[j] = new Tile();
                }
            }
        }

        public (uint, uint) FindIndexOfTile(Tile tile)
        {
            for (uint i = 0; i < Grid.Length; i++)
            {
                Tile[] arrayOfTiles = Grid[i];
                
                for (uint j = 0; j < arrayOfTiles.Length; j++)
                {
                    Tile currentTile = arrayOfTiles[j];
                    
                    if (currentTile == tile)
                    {
                        return (i, j);
                    }
                    
                }
            }

            throw new ArgumentException("No matching tile");
        }

        public void SetNextStateOfTile(Tile theTile)
        {
            List<Tile> liveNeighbors = this.FindLiveNeighbors(theTile);

            if (theTile.State == TileState.Alive)
            {
                if (liveNeighbors.Count > 3)
                {
                    theTile.NextState = TileState.Dead;
                }
                else if (liveNeighbors.Count < 2)
                {
                    theTile.NextState = TileState.Dead;
                }
                else if (liveNeighbors.Count == 2 || liveNeighbors.Count == 3)
                {
                    theTile.NextState = TileState.Alive;
                }
                else
                {
                    theTile.NextState = TileState.Dead;
                }
            }
            else if (theTile.State == TileState.Dead)
            {
                if (liveNeighbors.Count == 3)
                {
                    theTile.NextState = TileState.Alive;
                }  
                else
                {
                    theTile.NextState = TileState.Dead;
                }
            }           
        }

        public ICollection<Tile> FindNeighbors(Tile tile)
        {
            (uint, uint) tileIndex = FindIndexOfTile(tile);

            Tile top, topLeft, left, topRight, right, bottom, bottomLeft, bottomRight;
            var neighbors = new HashSet<Tile>();
            
            if (tileIndex.Item1 > 0)
            {
                top = Grid[tileIndex.Item1 - 1][tileIndex.Item2];
                neighbors.Add(top);   
                
                if (tileIndex.Item2 > 0 )
                {
                    topLeft = Grid[tileIndex.Item1 - 1][tileIndex.Item2 - 1];
                    left = Grid[tileIndex.Item1][tileIndex.Item2 - 1];
                    neighbors.Add(topLeft);
                    neighbors.Add(left);
                }

                if (tileIndex.Item2 < (Grid[0].Length - 1))
                {
                    topRight = Grid[tileIndex.Item1 - 1][tileIndex.Item2 + 1];
                    right = Grid[tileIndex.Item1][tileIndex.Item2 + 1];
                    neighbors.Add(topRight);
                    neighbors.Add(right); 
                }
            }

            if (tileIndex.Item1 < Grid.Length - 1)
            {
                bottom = Grid[tileIndex.Item1 + 1][tileIndex.Item2];
                neighbors.Add(bottom);

                if (tileIndex.Item2 > 0 )
                {
                    bottomLeft = Grid[tileIndex.Item1 + 1][tileIndex.Item2 - 1];
                    neighbors.Add(bottomLeft);
                }

                if (tileIndex.Item2 < (Grid[0].Length - 1))
                {
                    bottomRight = Grid[tileIndex.Item1 + 1][tileIndex.Item2 + 1];
                    neighbors.Add(bottomRight);
                }
            }
            
            return neighbors;
        }
        
        public List<Tile> FindLiveNeighbors(Tile tile)
        {
            var neighbors = FindNeighbors(tile);
            List<Tile> liveNeighbors = new List<Tile>();

            foreach (var neighbor in neighbors)
            {
                if (neighbor.State == TileState.Alive)
                {
                    liveNeighbors.Add(neighbor);
                }
            }

            return liveNeighbors;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Tile[] tiles in Grid)
            {
                foreach (var tile in tiles)
                {
                    tile.Draw(target, states);
                }
            }
        }
    }
    
 
}