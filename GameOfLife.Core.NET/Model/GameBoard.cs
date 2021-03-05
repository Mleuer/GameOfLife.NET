using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using static GameOfLife.Core.NET.Config.Configuration;

namespace GameOfLife.Core.NET.Model
{
    public class GameBoard
    {
	    public uint Width
	    {
		    get { return (uint) Grid.Length; }
	    }
	    
	    public uint Height
	    {
		    get { return (uint) Grid[0].Length; }
	    }
        public Tile[][] Grid { get; set; }

        public GameBoard(uint gameBoardWidth = GameBoardWidth, uint gameBoardHeight = GameBoardHeight)
        {
            Grid = new Tile[gameBoardWidth][];
            for (int i = 0; i < gameBoardWidth; i++)
            {
                Grid[i] = new Tile[gameBoardHeight];
                Tile[] tiles = Grid[i];
                
                for (int j = 0; j < gameBoardHeight; j++)
                {
                    tiles[j] = new Tile();
                }
            }
        }

        public GameBoard(Tile[][] grid)
        {
            Grid = grid;
        }

        public void UpdateState()
        {
            SetNextStateOfTiles();
            UpdateStateOfTiles();
        }
        private void UpdateStateOfTiles()
        {
            foreach (Tile[] rowOfTiles in Grid)
            {
                foreach (Tile tile in rowOfTiles)
                {
                    tile.State = tile.NextState;
                }
            }
        }
        private void SetNextStateOfTiles()
        {
            foreach (Tile[] rowOfTiles in Grid)
            {
                foreach (Tile tile in rowOfTiles)
                {
                    this.SetNextStateOfTile(tile);
                }
            }
        }

        public void SetTilesAliveAtRandom(uint numberOfTiles)
        {
            var random = new Random();
            
            if (numberOfTiles < (Width * Height))
            { 
                for (uint i = 0; i < numberOfTiles; i++)
                {
                   var randomXIndex = random.Next(0, (int) Height);
                   var randomYIndex = random.Next(0, (int) Width);
                   var randomTile = Grid[(uint) randomYIndex][(uint) randomXIndex];
                   randomTile.State = TileState.Alive;
                } 
            }
            else
            {
                throw new ArgumentException("Argument out of range of GameBoard.");
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
        
    }

    public class GraphicalGameBoard : GameBoard, Drawable
    {
        public GraphicalGameBoard(uint gameBoardWidth = GameBoardWidth, uint gameBoardHeight = GameBoardHeight)
        {
            Grid = new GraphicalTile[gameBoardWidth][] as Tile[][];
            for (int i = 0; i < gameBoardWidth; i++)
            {
                Grid[i] = new GraphicalTile[gameBoardHeight] as Tile[];
                GraphicalTile[] tiles = (GraphicalTile[]) Grid[i];
                
                for (int j = 0; j < gameBoardHeight; j++)
                {
                    tiles[j] = new GraphicalTile(Find2DCoordinateOfTile(
                                                                        boardWidth: Width,
                                                                        boardHeight: Height,
                                                                        outerArrayIndex: i, 
                                                                        innerArrayIndex: j));
                    AdjustSizeOfTile(tiles[j]);
                }
            }
        }

        private void AdjustSizeOfTile(GraphicalTile graphicalTile)
        {
            Vector2u size = graphicalTile.TileSprite.Texture.Size;
            var desiredSize = new Vector2u(ComputeTileWidth(Width), ComputeTileHeight(Height));
            var scale = new Vector2f(desiredSize.X / (float) size.X, desiredSize.Y / (float) size.Y);
            graphicalTile.TileSprite.Scale = scale;
        }

        public GraphicalGameBoard(GraphicalTile[][] grid)
        {
            Grid = grid as Tile[][];
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Tile[] tiles in Grid)
            {
	            if (tiles is GraphicalTile[] graphicalTiles)
	            {
		            foreach (GraphicalTile tile in graphicalTiles)
		            {
			            tile.Draw(target, states);
		            }
	            }
            }
        }

        public static (uint, uint) Find2DCoordinateOfTile(uint boardWidth, uint boardHeight, int outerArrayIndex, int innerArrayIndex)
        {
            uint yPosition = (uint)(outerArrayIndex * boardHeight) + (uint)(outerArrayIndex * Margin);
            uint xPosition = (uint)(innerArrayIndex * boardWidth) + (uint)(innerArrayIndex * Margin);

            return (xPosition, yPosition);
        }
    }
    
 
}