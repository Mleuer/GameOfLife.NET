using System;
using System.Collections.Generic;
using SFML.Graphics;
using static GameOfLife.NET.Config.Configuration;

namespace GameOfLife.NET.Model


{
    public class GameBoard
    {
        public Tile[][] Grid { get; set; }

        public GameBoard()
        {
            Grid = new Tile[Config.Configuration.GameBoardWidth][];
            for (int i = 0; i < Config.Configuration.GameBoardWidth; i++)
            {
                Grid[i] = new Tile[Config.Configuration.GameBoardHeight];
                Tile[] tiles = Grid[i];
                
                for (int j = 0; j < Config.Configuration.GameBoardHeight; j++)
                {
                    tiles[j] = new Tile();
                }
            }
        }

        public GameBoard(Tile[][] grid)
        {
            Grid = grid;
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

        
    }

    public class GraphicalGameBoard : GameBoard, Drawable
    {
        public GraphicalGameBoard()
        {
            Grid = new GraphicalTile[Config.Configuration.GameBoardWidth][];
            for (int i = 0; i < Config.Configuration.GameBoardWidth; i++)
            {
                Grid[i] = new GraphicalTile[Config.Configuration.GameBoardHeight];
                GraphicalTile[] tiles = (GraphicalTile[]) Grid[i];
                
                for (int j = 0; j < Config.Configuration.GameBoardHeight; j++)
                {
                    tiles[j] = new GraphicalTile(FindPositionOfTile(i, j));
                }
            }
        }
        public GraphicalGameBoard(GraphicalTile[][] grid)
        {
            Grid = grid as GraphicalTile[][];
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (GraphicalTile[] tiles in Grid)
            {
                foreach (var tile in tiles)
                {
                    tile.Draw(target, states);
                }
            }
        }

        public static (uint, uint) FindPositionOfTile(int outerArrayIndex, int innerArrayIndex)
        {
            var yPosition = (uint)(outerArrayIndex * TileHeight);
            var xPosition = (uint)(innerArrayIndex * TileWidth);

            return (xPosition, yPosition);
        }
    }
    
 
}