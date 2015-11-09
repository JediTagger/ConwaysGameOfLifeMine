using System;
using ConwaysGameOfLife;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TNJGameOfLifeTests
{
    [TestClass]
    public class OsTest
    {
        [TestMethod]
        public void IsThereABoard()
        {
            Oscillator osc = new Oscillator();
            List<List<bool>> board = osc.GetBoardCells();
            Assert.IsNotNull(board);
        }
        [TestMethod]
        public void IsCellAlive()
        {
            Oscillator osc = new Oscillator();
            List<List<bool>> board = osc.GetBoardCells();
            Assert.IsTrue(board[0][1]);
            Assert.IsFalse(board[1][1]);
        }
    }
}
