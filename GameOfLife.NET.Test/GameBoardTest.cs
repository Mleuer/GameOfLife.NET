using System.Collections.Generic;
using GameOfLife.NET.Model;
using NUnit.Framework;

namespace GameOfLife.NET.Test
{
    public class GameBoardTest
    {
        [Test]
        public void FindNeighborsShouldReturnAdjacentTiles()
        {            
            Tile tile = new Tile();
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {new Tile(), tile, new Tile()},
                new Tile[] {new Tile(), new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);

            List<Tile> neighbors = gameBoard.FindNeighbors(tile);

            Assert.Contains(grid[2][2], neighbors);

        }

        [Test]
        public void FindIndexOfTileShouldReturnCorrectIndex()
        {
            Tile tile = new Tile();
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {new Tile(), tile, new Tile()},
                new Tile[] {new Tile(), new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);
            (uint, uint) tileIndex = gameBoard.FindIndexOfTile(tile);
            
            Tile theSameTile = gameBoard.Grid[tileIndex.Item1][tileIndex.Item2];
            
            Assert.AreSame(tile, theSameTile);
            
            

        }
    }
}