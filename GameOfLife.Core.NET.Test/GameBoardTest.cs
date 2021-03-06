using System.Collections.Generic;
using GameOfLife.Core.NET.Model;
using NUnit.Framework;
using static GameOfLife.Core.NET.Config.Configuration;

namespace GameOfLife.Core.NET.Test
{
    public class GameBoardTest
    {

        [Test]
        public void UpdateStateShouldGiveNextStateOfABlinker()
        {
            Tile[][] grid = {
                new [] {new Tile(), new Tile {State = TileState.Alive}, new Tile()},
                new [] {new Tile(), new Tile {State = TileState.Alive}, new Tile()},
                new [] {new Tile(), new Tile {State = TileState.Alive}, new Tile()}
            };
            
            var gameBoard = new GameBoard(grid);
            gameBoard.UpdateState();
            
            Assert.AreEqual(TileState.Alive, grid[1][0].State );
            Assert.AreEqual(TileState.Alive, grid[1][2].State );
            Assert.AreEqual(TileState.Dead, grid[0][1].State );
            Assert.AreEqual(TileState.Dead, grid[2][1].State );
        }
        
        [Test]
        public void FindNeighborsShouldReturnAdjacentTilesWhenTileIsSurroundedByTiles()
        {            
            Tile tile = new Tile();
            
            Tile[][] grid = {
                new [] {new Tile(), new Tile(), new Tile()},
                new [] {new Tile(), tile,       new Tile()},
                new [] {new Tile(), new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);

            var neighbors = gameBoard.FindNeighbors(tile);

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
            
            Tile[][] grid = {
                new [] {new Tile(), new Tile(), new Tile()},
                new [] {new Tile(), new Tile(), new Tile()},
                new [] {tile,       new Tile(), new Tile()}
            };
            
            GameBoard gameBoard = new GameBoard(grid);

            var neighbors = gameBoard.FindNeighbors(tile);

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
            
            Tile[][] grid = {
                new [] {new Tile(), new Tile(), new Tile()},
                new [] {new Tile(), tile,       new Tile()},
                new [] {new Tile(), new Tile(), new Tile()}
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

            Tile[][] grid = {
                new [] {new Tile { State = TileState.Alive }, new Tile(), new Tile()},
                new [] {new Tile(),                           tile,       new Tile()},
                new [] {new Tile(),                           new Tile(), new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Dead, tile.NextState);
        }
        
        [Test]
        public void SetNextStateOfTileShouldSetNextStateToAliveWhenLiveTileHasTwoOrThreeThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Alive };

            Tile[][] grid = {
                new [] {new Tile(),                           new Tile(),                           new Tile { State = TileState.Alive }},
                new [] {new Tile { State = TileState.Alive }, tile,                                 new Tile()},
                new [] {new Tile(),                           new Tile { State = TileState.Alive }, new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Alive, tile.NextState);
        }

        [Test]
        public void SetNextStateOfTileShouldSetNextStateToDeadWhenLiveTileHasMoreThanThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Alive };

            Tile[][] grid = {
                new [] {new Tile { State = TileState.Alive }, new Tile(),                           new Tile { State = TileState.Alive }},
                new [] {new Tile { State = TileState.Alive }, tile,                                 new Tile()},
                new [] {new Tile(),                           new Tile { State = TileState.Alive }, new Tile()}
            };

            var gameBoard = new GameBoard(grid);

            gameBoard.SetNextStateOfTile(tile);

            Assert.AreEqual(TileState.Dead, tile.NextState);
        }

        [Test]
        public void SetNextStateOfTileShouldSetNextStateToAliveWhenDeadTileHasExactlyThreeLiveNeighbors()
        {
            var tile = new Tile { State = TileState.Dead };
            
            Tile[][] grid = {
                new [] {new Tile{ State = TileState.Alive }, new Tile(),                          new Tile { State = TileState.Alive }},
                new [] {new Tile(),                          tile,                                new Tile()},
                new [] {new Tile(),                          new Tile{ State = TileState.Alive }, new Tile()}
            };
  
            var gameBoard = new GameBoard(grid);
            
            gameBoard.SetNextStateOfTile(tile);
            
            Assert.AreEqual(TileState.Alive, tile.NextState);
        }

        [Test]

        public void FindPositionOfTileShouldFind2DCoordinates()
        {
	        uint boardWidth = 32;
	        uint boardHeight = 32;
	        
	        (uint, uint) topLeftPosition = GraphicalGameBoard.Find2DCoordinateOfTile(boardWidth: boardWidth, boardHeight: boardHeight, outerArrayIndex: 0, innerArrayIndex: 0);
            (uint, uint) topRightPosition = GraphicalGameBoard.Find2DCoordinateOfTile(boardWidth: boardWidth, boardHeight: boardHeight, outerArrayIndex: 0, innerArrayIndex: 1);
            (uint, uint) bottomLeftPosition = GraphicalGameBoard.Find2DCoordinateOfTile(boardWidth: boardWidth, boardHeight: boardHeight, outerArrayIndex: 1, innerArrayIndex: 0);
            (uint, uint) bottomRightPosition = GraphicalGameBoard.Find2DCoordinateOfTile(boardWidth: boardWidth, boardHeight: boardHeight, outerArrayIndex: 1, innerArrayIndex: 1);

            Assert.AreEqual( (0u, 0u), topLeftPosition);
            Assert.AreEqual( (36u, 0u), topRightPosition);
            Assert.AreEqual( (0u, 36u), bottomLeftPosition);
            Assert.AreEqual( (36u, 36u), bottomRightPosition);
        }
    }
}