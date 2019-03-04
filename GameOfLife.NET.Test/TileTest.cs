using System;
using GameOfLife.NET;
using GameOfLife.NET.Model;
using NUnit.Framework;

namespace GameOfLife.NET.Test
{
    
    public class TileTest
    {
        [Test]
        public void ChangeStateShouldChangeLivingStateToDeadState()
        {
            var tile = new Tile();
            tile.State = TileState.alive;
            
            tile.ChangeState();
            
            Assert.AreEqual(TileState.dead, tile.State);
        }
        
        [Test]
        public void ChangeStateShouldChangeDeadStateToAlive()
        {
            var tile = new Tile();
            tile.State = TileState.dead;
            
            tile.ChangeState();
            
            Assert.AreEqual(TileState.alive, tile.State);
        }
    }
}