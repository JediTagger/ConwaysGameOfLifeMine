using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GameOfLife
    {
        public bool[,] grid;

        public GameOfLife(int row, int col)
        {
            grid = new bool[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    grid[i, j] = false;
                }
            }
        }

        public int CountLivingNeighbors(int row, int col)
        {
            int neighbors = 0;
            if (grid[row - 1, col - 1])
            { neighbors++; }
            if (grid[row - 1, col])
            { neighbors++; }
            if (grid[row - 1, col + 1])
            { neighbors++; }
            if (grid[row, col - 1])
            { neighbors++; }
            if (grid[row, col + 1])
            { neighbors++; }
            if (grid[row + 1, col + 1])
            { neighbors++; }
            if (grid[row + 1, col])
            { neighbors++; }
            if (grid[row + 1, col - 1])
            { neighbors++; }
            return neighbors;
        }

        public int CountLivingNeighbors2(int row, int col)
        {
            int neighbors = 0;

            if the neighbors row & col is not grid's row is not +/- 1 and col +/-1

            if (grid[row - 1, col - 1])
            { neighbors++; }
            if (grid[row - 1, col])
            { neighbors++; }
            if (grid[row - 1, col + 1])
            { neighbors++; }
            if (grid[row, col - 1])
            { neighbors++; }
            if (grid[row, col + 1])
            { neighbors++; }
            if (grid[row + 1, col + 1])
            { neighbors++; }
            if (grid[row + 1, col])
            { neighbors++; }
            if (grid[row + 1, col - 1])
            { neighbors++; }
            return neighbors;
        }

        public bool UnderPopulation(int row, int col)
        {
            bool tester = grid[row, col];
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if(tester)
            {
                if(neighbors < 2)
                {
                    return false;
                } else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RemainAlive(int row, int col)
        {
            bool tester = grid[row, col];
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if (tester)
            {
                if (neighbors == 2 || neighbors == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool OverPopulation(int row, int col)
        {
            bool tester = grid[row, col];
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if (tester)
            {
                if (neighbors > 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public bool LivingLivesOrDies(int row, int col)
        {
            bool tester = grid[row, col];
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if (tester)
            {
                if (neighbors == 2 || neighbors == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeadLivesOrDies(int row, int col)
        {
            bool tester = grid[row, col];
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if (tester)
            {
                return true;
            }
            else
            {
                if(neighbors == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TheOneRule(int row, int col)
        {
            int neighbors = 0;
            neighbors = CountLivingNeighbors(row, col);
            if (grid[row,col])
            {
                if (neighbors == 2 || neighbors == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (neighbors == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public class FauxGameOfLife : Board
    {
        private List<List<bool>> cells = new List<List<bool>>();
        private Dictionary<char, List<List<bool>>> font = new Dictionary<char, List<List<bool>>>();
        private string phrase = "HELLO WORLD ";
        private int index = 0;

        public FauxGameOfLife()
        {
            List<List<bool>> letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['H'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['E'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['L'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['O'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, false }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, true, false }));
            letter.Add(new List<bool>(new bool[] { true, false, true, false, true, false }));
            letter.Add(new List<bool>(new bool[] { true, false, true, false, true, false }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, false, false }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['W'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['R'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, true, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, true, true, false, true }));
            letter.Add(new List<bool>(new bool[] { true, false, false, false, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font['D'] = letter;

            letter = new List<List<bool>>();
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            letter.Add(new List<bool>(new bool[] { true, true, true, true, true, true }));
            font[' '] = letter;

            Tick();
        }

        public List<List<bool>> ToList()
        {
            return cells;
        }

        public void Tick()
        {
            if(index >= phrase.Length)
            {
                index = 0;
            }
            char letter = phrase[index];
            cells = font[letter];
            index++;
        }
    }
}
