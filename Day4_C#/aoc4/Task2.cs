using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc4
{
    class Task2
    {
        private GameData gameData;
        private int score;
        private int[] indexesFinished;
        //private int lastNumber;
        public Task2(GameData gameData)
        {
            this.gameData = gameData;
            Initialize();
        }

        private void Initialize()
        {
            int length = gameData.Boards.Count;
            indexesFinished = new int[length];
            for (int i = 0; i < length; i++){
                indexesFinished[i] = -1;
            }
        }

        public void Calculate()
        {
            foreach (int number in gameData.NumbersToBeTested)
            {
                foreach (int[,] board in gameData.Boards)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (board[i, j] == number)
                            {
                                board[i, j] = -1;
                            }
                        }
                    }
                }

                foreach (int[,] board in gameData.Boards)
                {
                    int[] columnSum = new int[5];

                    for (int i = 0; i < 5; i++)
                    {
                        int rowSum = 0;

                        for (int j = 0; j < 5; j++)
                        {
                            rowSum += board[i, j];
                            columnSum[j] += board[i, j];
                        }

                        if (rowSum == -5) indexesFinished[gameData.Boards.IndexOf(board)] = 0;
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if(columnSum[i] == -5) indexesFinished[gameData.Boards.IndexOf(board)] = 0;
                    }
                    if (indexesFinished.Sum() == 0) 
                    {
                        CalculateScore(number, board);
                        return;
                    }
                }

            }
        }

        private void CalculateScore(int lastNumber, int[,] lastBoard)
        {
            int total = 0;

            for (int k = 0; k < 5; k++)
                for (int l = 0; l < 5; l++)
                    if (lastBoard[k, l] >= 0)
                        total += lastBoard[k, l];
            score = total * lastNumber;
        }

        public int GetResult()
        {

            return score;
        }
    }
}
