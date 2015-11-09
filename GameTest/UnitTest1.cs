using System;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameTest
{
    [TestClass]
    public class ConwayTest
    {

        [TestMethod]
        public void IsThereAGame()
        {
            GameOfLife test = new GameOfLife(0, 0);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void MeasureGrid()
        {
            GameOfLife test = new GameOfLife(2, 2);
            Assert.AreEqual(4, test.grid.Length);
        }

        [TestMethod]
        public void TestFalse()
        {
            GameOfLife test = new GameOfLife(2, 2);
            Assert.IsFalse(test.grid[1,1]);
        }

        [TestMethod]
        public void TestLiving()
        {
            GameOfLife test = new GameOfLife(2, 2);
            test.grid[1, 1] = true;
            Assert.IsTrue(test.grid[1, 1]);
        }

        [TestMethod]
        public void CountLivingNeighborsWorking()
        {
            GameOfLife test = new GameOfLife(3, 3);
            test.grid[0, 0] = true;
            test.grid[1, 0] = true;
            Assert.AreEqual(2, test.CountLivingNeighbors(1, 1));
        }

        [TestMethod]
        //rule 1 - Any live cell with fewer than two live 
        //neighbours dies.
        public void UnderPopulationTest()
        {
            GameOfLife test1 = new GameOfLife(3, 3);
            test1.grid[1, 1] = true;
            Assert.IsFalse(test1.UnderPopulation(1, 1));
        }

        [TestMethod]
        //rule 2 - Any live cell with two or three live neighbours 
        //lives.
        public void RemainAliveTest()
        {
            GameOfLife test = new GameOfLife(3, 3);
            test.grid[1, 1] = true;
            test.grid[1, 0] = true;
            test.grid[2, 0] = true;
            Assert.IsTrue(test.RemainAlive(1, 1));
            //another way of testing the same thing
            Assert.AreEqual(test.grid[1, 1], test.RemainAlive(1, 1));
        }

        [TestMethod]
        //rule 3 - Any live cell with more than three live neighbours
        //dies.
        public void OverPopulationTest()
        {
            GameOfLife test = new GameOfLife(3, 3);
            test.grid[1, 1] = true;
            test.grid[0, 0] = true;
            test.grid[1, 0] = true;
            test.grid[2, 0] = true;
            //test.grid[2, 1] = true;
            Assert.IsFalse(test.OverPopulation(1, 1));
            //Assert.AreEqual(1, test.CountLivingNeighbors(1, 1));
        }

    }
}
