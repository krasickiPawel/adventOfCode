using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aoc4
{
    class FileRead
    {
        public static GameData getData()
        {
            GameData gameData = new GameData();

            string file = File.ReadAllText(@"C:\Users\Paweł\Documents\studia\3 rok\AoC\day4\input4.txt");
            string[] segmentedFile = file.Split("\n");
            string[] firstLine = segmentedFile[0].Split(",");

            foreach (string numberAsString in firstLine)
            {
                gameData.AddNumberToBeTested(Convert.ToInt32(numberAsString));
            }

            List<string> fileLinesList = segmentedFile.ToList();
            fileLinesList.RemoveAt(0);

            List<string> tempList = new List<string>();
            for (int i = 0; i < fileLinesList.Count; i++)
            {
                if (tempList.Count < 6) tempList.Add(fileLinesList[i]);
                else
                {
                    int[,] board = new int[5, 5];
                    tempList.RemoveAt(0);
                    for (int j = 0; j < 5; j++)
                    {
                        var line = tempList[j].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        for (int k = 0; k < 5; k++)
                        {
                            board[j, k] = Convert.ToInt32(line[k]);
                        }
                    }
                    gameData.AddBoard(board);
                    tempList.Clear();
                    tempList.Add(fileLinesList[i]);
                }
            }

            /*
            foreach(int number in gameData.NumbersToBeTested)
            {
                Console.Write($"{number} ");
            }
            */
            /*
            foreach (int[,] gameBoard in gameData.Boards)
            {
                for(int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{gameBoard[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            */

            return gameData;
        }
    }
}
