using System;
using System.Collections.Generic;
using static GameOfLife.NET.Config.Configuration;
namespace GameOfLife.NET.Model


{
    public class GameBoard
    {
        public Tile[][] Grid { get; private set; } = new Tile[GameBoardWidth][];

        public GameBoard(Tile[][] grid)
        {
            Grid = grid;
        }

        public (uint, uint) FindIndexOfTile(Tile theTile)
        {
            (uint, uint) index = (0, 0);
            bool matchFound = false;
           
            for (uint i = 0; i < Grid.Length; i++)
            {
                Tile[] arrayOfTiles = Grid[i];
                
                for (uint j = 0; j < arrayOfTiles.Length; j++)
                {
                    Tile tile = arrayOfTiles[j];
                    
                    if (tile == theTile)
                    {
                        index = (i, j);
                        matchFound = true;
                    }
                    
                }
            }
            if (matchFound)
            {
                return index;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<Tile> FindNeighbors(Tile theTile)
        {
            var game1 = new GameBoard(new Tile[GameBoardWidth][]);
        
            (uint, uint) tileIndex = FindIndexOfTile(theTile);

            Tile top, topLeft, left, topRight, right, bottom, bottomLeft, bottomRight;
            List<Tile> neighbors = new List<Tile>();

            

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
        
        
        
        
    }
    
 
}