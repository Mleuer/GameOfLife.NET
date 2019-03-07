using System.Collections.Generic;
using GameOfLife.NET.Model;
using NUnit.Framework;

namespace GameOfLife.NET.Test
{
    public class GameBoardTest
    {
        [Test]
        public void FindNeighborsShouldReturnAdjacentTilesWhenTileIsSurroundedByTiles()
        {            
            Tile tile = new Tile();
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {new Tile(), tile,       new Tile()},
                new Tile[] {new Tile(), new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);

            List<Tile> neighbors = gameBoard.FindNeighbors(tile);

            List<Tile> expectedNeighbors = new List<Tile>
            {
                grid[0][0], grid[0][1], grid[0][2],
                grid[1][0],             grid[1][2],
                grid[2][0], grid[2][1], grid[2][2]
            };

            CollectionAssert.AreEquivalent(expectedNeighbors, neighbors);
        }
        
        [Test]
        public void FindNeighborsShouldReturnAdjacentTilesWhenTileIsInTheCorner()
        {            
            Tile tile = new Tile();
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {tile,       new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);

            List<Tile> neighbors = gameBoard.FindNeighbors(tile);

            List<Tile> expectedNeighbors = new List<Tile>
            {
                grid[1][0], grid[1][1],
                            grid[2][1]
            };

            CollectionAssert.AreEquivalent(expectedNeighbors, neighbors);
        }
        
        [Test]
        public void FindIndexOfTileShouldReturnCorrectIndex()
        {
            Tile tile = new Tile();
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(), new Tile(), new Tile()},
                new Tile[] {new Tile(), tile,       new Tile()},
                new Tile[] {new Tile(), new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);
            (uint, uint) tileIndex = gameBoard.FindIndexOfTile(tile);
            
            Tile theSameTile = gameBoard.Grid[tileIndex.Item1][tileIndex.Item2];
            
            Assert.AreSame(tile, theSameTile);
        }
        
        [Test]
        public void SetNextStateOfTileShouldSetNextStateToDeadWhenLiveTileHasLessThanTwoLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Alive };

            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile { State = TileState.Alive }, new Tile(), new Tile()},
                new Tile[] {new Tile(),                           tile,       new Tile()},
                new Tile[] {new Tile(),                           new Tile(), new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Dead, tile.NextState);
        }
        
        [Test]
        public void SetNextStateOfTileShouldSetNextStateToAliveWhenLiveTileHasTwoOrThreeThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Alive };

            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile(),                           new Tile(),                           new Tile { State = TileState.Alive }},
                new Tile[] {new Tile { State = TileState.Alive }, tile,                                 new Tile()},
                new Tile[] {new Tile(),                           new Tile { State = TileState.Alive }, new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Alive, tile.NextState);
        }

        [Test]
        public void SetNextStateOfTileShouldSetNextStateToDeadWhenLiveTileHasMoreThanThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Alive };

            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile { State = TileState.Alive }, new Tile(),                           new Tile { State = TileState.Alive }},
                new Tile[] {new Tile { State = TileState.Alive }, tile,                                 new Tile()},
                new Tile[] {new Tile(),                           new Tile { State = TileState.Alive }, new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Dead, tile.NextState);
        }

        [Test]
        public void SetNextStateOfTileShouldSetNextStateToAliveWhenDeadTileHasExactlyThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Dead };
            
            Tile[][] grid = new Tile[][]
            {
                new Tile[] {new Tile{ State = TileState.Alive }, new Tile(),                          new Tile { State = TileState.Alive }},
                new Tile[] {new Tile(),                          tile,                                new Tile()},
                new Tile[] {new Tile(),                          new Tile{ State = TileState.Alive }, new Tile()}
            };
  
            var gameBoard = new GameBoard(grid);
            
            gameBoard.SetNextStateOfTile(tile);
            
            Assert.AreEqual(TileState.Alive, tile.NextState);
        }
    }
}