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
            Assert.IsFalse(test.grid[1, 1]);
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
            test.grid[2, 1] = true;
            Assert.IsFalse(test.OverPopulation(1, 1));
        }

        [TestMethod]
        public void LivingTests()
        {
            //dead stays dead
            GameOfLife test1 = new GameOfLife(3, 3);
            test1.grid[1, 1] = false;
            Assert.IsFalse(test1.LivingLivesOrDies(1, 1));
            //living with zero living neighbors dies
            GameOfLife test2 = new GameOfLife(3, 3);
            test2.grid[1, 1] = true;
            Assert.IsFalse(test2.LivingLivesOrDies(1, 1));
            //living with 1 living neighbor dies
            GameOfLife test3 = new GameOfLife(3, 3);
            test3.grid[1, 1] = true;
            test3.grid[1, 0] = true;
            Assert.IsFalse(test3.LivingLivesOrDies(1, 1));
            //living with 2 living neighbors lives
            GameOfLife test4 = new GameOfLife(3, 3);
            test4.grid[1, 1] = true;
            test4.grid[1, 0] = true;
            test4.grid[1, 2] = true;
            Assert.IsTrue(test4.LivingLivesOrDies(1, 1));
            //living with 3 living neighbors lives
            GameOfLife test5 = new GameOfLife(3, 3);
            test5.grid[1, 1] = true;
            test5.grid[0, 0] = true;
            test5.grid[1, 0] = true;
            test5.grid[2, 0] = true;
            Assert.IsTrue(test5.LivingLivesOrDies(1, 1));
            //living with 4 (or more) living neighbors dies
            GameOfLife test6 = new GameOfLife(3, 3);
            test6.grid[1, 1] = true;
            test6.grid[0, 0] = true;
            test6.grid[1, 0] = true;
            test6.grid[2, 0] = true;
            test6.grid[1, 2] = true;
            Assert.IsFalse(test6.LivingLivesOrDies(1, 1));
        }

        [TestMethod]
        public void DeadTests()
        {
            //living remains alive
            GameOfLife test1 = new GameOfLife(3, 3);
            test1.grid[1, 1] = true;
            Assert.IsTrue(test1.DeadLivesOrDies(1, 1));
            //dead with zero living neighbors remains dead
            GameOfLife test2 = new GameOfLife(3, 3);
            test2.grid[1, 1] = false;
            Assert.IsFalse(test2.DeadLivesOrDies(1, 1));
            //dead with 2 living neighbors remains dead
            GameOfLife test3 = new GameOfLife(3, 3);
            test3.grid[1, 1] = false;
            test3.grid[1, 0] = true;
            test3.grid[0, 1] = true;
            Assert.IsFalse(test3.DeadLivesOrDies(1, 1));
            //dead with 3 living neighbors becomes alive
            GameOfLife test4 = new GameOfLife(3, 3);
            test4.grid[1, 1] = false;
            test4.grid[1, 0] = true;
            test4.grid[0, 1] = true;
            test4.grid[0, 0] = true;
            Assert.IsTrue(test4.DeadLivesOrDies(1, 1));
            //dead with 4 living neighbors remains dead
            GameOfLife test5 = new GameOfLife(3, 3);
            test5.grid[1, 1] = false;
            test5.grid[1, 0] = true;
            test5.grid[0, 1] = true;
            test5.grid[0, 0] = true;
            test5.grid[0, 2] = true;
            Assert.IsFalse(test5.DeadLivesOrDies(1, 1));
        }
        
        [TestMethod]
        public void OneRuleTest()
        {
            //dead with zero living neighbors remains dead
            GameOfLife test2 = new GameOfLife(3, 3);
            test2.grid[1, 1] = false;
            Assert.IsFalse(test2.TheOneRule(1, 1));
            //dead with 2 living neighbors remains dead
            GameOfLife test3 = new GameOfLife(3, 3);
            test3.grid[1, 1] = false;
            test3.grid[1, 0] = true;
            test3.grid[0, 1] = true;
            Assert.IsFalse(test3.TheOneRule(1, 1));
            //dead with 3 living neighbors becomes alive
            GameOfLife test4 = new GameOfLife(3, 3);
            test4.grid[1, 1] = false;
            test4.grid[1, 0] = true;
            test4.grid[0, 1] = true;
            test4.grid[0, 0] = true;
            Assert.IsTrue(test4.TheOneRule(1, 1));
            //dead with 4 living neighbors remains dead
            GameOfLife test5 = new GameOfLife(3, 3);
            test5.grid[1, 1] = false;
            test5.grid[1, 0] = true;
            test5.grid[0, 1] = true;
            test5.grid[0, 0] = true;
            test5.grid[0, 2] = true;
            Assert.IsFalse(test5.TheOneRule(1, 1));
            //living with zero living neighbors dies
            GameOfLife test6 = new GameOfLife(3, 3);
            test6.grid[1, 1] = true;
            Assert.IsFalse(test6.TheOneRule(1, 1));
            //living with 1 living neighbor dies
            GameOfLife test7 = new GameOfLife(3, 3);
            test7.grid[1, 1] = true;
            test7.grid[1, 0] = true;
            Assert.IsFalse(test7.TheOneRule(1, 1));
            //living with 2 living neighbors lives
            GameOfLife test8 = new GameOfLife(3, 3);
            test8.grid[1, 1] = true;
            test8.grid[1, 0] = true;
            test8.grid[1, 2] = true;
            Assert.IsTrue(test8.TheOneRule(1, 1));
            //living with 3 living neighbors lives
            GameOfLife test9 = new GameOfLife(3, 3);
            test9.grid[1, 1] = true;
            test9.grid[0, 0] = true;
            test9.grid[1, 0] = true;
            test9.grid[2, 0] = true;
            Assert.IsTrue(test9.TheOneRule(1, 1));
            //living with 4 (or more) living neighbors dies
            GameOfLife test10 = new GameOfLife(3, 3);
            test10.grid[1, 1] = true;
            test10.grid[0, 0] = true;
            test10.grid[1, 0] = true;
            test10.grid[2, 0] = true;
            test10.grid[1, 2] = true;
            Assert.IsFalse(test10.TheOneRule(1, 1));
        }

        [TestMethod]
        public void BoundarySide()
        {
            GameOfLife test1 = new GameOfLife(3, 3);
            test1.grid[0, 0] = true;
            test1.grid[0, 1] = true;
            Assert.AreEqual(1, test1.CountLivingNeighbors(0,0));
        }



    }
}
