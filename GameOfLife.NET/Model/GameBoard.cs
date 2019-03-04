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

        private (uint, uint) findIndexOfTile(Tile theTile)
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

        public List<Tile> FindNeighbors(Tile tile)
        {
            
        }
        
        
        
        
    }
    
 
}