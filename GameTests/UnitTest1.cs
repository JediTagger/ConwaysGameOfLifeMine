using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void IsThereABoard()
        {
            DansGameOfLife aNewBoard = new DansGameOfLife();
            bool expected = aNewBoard.cells[0][0];
            Assert.IsTrue(true == expected);
        }
        [TestMethod]
        public void DidCountLivingNeighborsWork()
        {
            DansGameOfLife aNewBoard = new DansGameOfLife();
            Assert.AreEqual(2, aNewBoard.CountLivingNeighbors(1, 1));
        }
    }
}
