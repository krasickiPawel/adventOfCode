using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc4
{
    class GameData
    {
        public List<int> NumbersToBeTested { get; }
        public List<int[,]> Boards { get; }

        public GameData()
        {
            this.NumbersToBeTested = new List<int>();
            this.Boards = new List<int[,]>();
        }

        public void AddBoard(int[,] board)
        {
            Boards.Add(board);
        }

        public void AddNumberToBeTested(int number)
        {
            NumbersToBeTested.Add(number);
        }
    }

}
