using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc4
{
    class Task1
    {
        private GameData gameData;
        private int score = 0;
        public Task1(GameData gameData)
        {
            this.gameData = gameData;
        }

        public void Calculate()
        {
            foreach(int number in gameData.NumbersToBeTested)
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
                        if (rowSum == -5)
                        {
                            int total = 0;
                            for (int k = 0; k < 5; k++)
                                for (int l = 0; l < 5; l++)
                                    if (board[k, l] >= 0)
                                        total += board[k, l];
                            score = total * number;
                            return;

                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (columnSum[i] == -5)
                        {
                            int total = 0;
                            for (int k = 0; k < 5; k++)
                                for (int l = 0; l < 5; l++)
                                    if (board[k, l] >= 0)
                                        total += board[k, l];
                            score = total * number;
                            return;
                        }
                    }
                }

            }
        }
        
        public int GetResult()
        {

            return score;
        }
    }
}
