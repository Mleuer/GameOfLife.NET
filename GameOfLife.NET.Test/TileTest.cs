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
            tile.State = TileState.Alive;
            
            tile.ChangeState();
            
            Assert.AreEqual(TileState.Dead, tile.State);
        }
        
        [Test]
        public void ChangeStateShouldChangeDeadStateToAlive()
        {
            var tile = new Tile();
            tile.State = TileState.Dead;
            
            tile.ChangeState();
            
            Assert.AreEqual(TileState.Alive, tile.State);
        }
    }
}