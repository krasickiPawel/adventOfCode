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
        private int[] indexesFinished;  //zapisanie ktore plansze juz wygraly (szukamy najbardziej przegranej czyli tej ktora wygra jako ostatnia - bedzie miala najdluzej -1)
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
                indexesFinished[i] = -1;        //przypisanie wszystkim plansza -1 czyli ze jeszcze graja. jak wygra plansza to jej wartosc w tej liscie zmieni sie na 0)
            }
        }

        public void Calculate()
        {
            foreach (int number in gameData.NumbersToBeTested)  //przebieg gry jak w task1
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

                foreach (int[,] board in gameData.Boards)   //delikatna roznica wzgledem task1 - zostana wymienione tylko roznice
                {                                           //sprawdzamy wszystkie plansze czy sa wygrane
                    int[] columnSum = new int[5];

                    for (int i = 0; i < 5; i++)
                    {
                        int rowSum = 0;

                        for (int j = 0; j < 5; j++)
                        {
                            rowSum += board[i, j];
                            columnSum[j] += board[i, j];
                        }

                        if (rowSum == -5) indexesFinished[gameData.Boards.IndexOf(board)] = 0;  //jesli plansza zakonczy gre to jej indeksowi w indexesFinished przypisywane jest 0
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if(columnSum[i] == -5) indexesFinished[gameData.Boards.IndexOf(board)] = 0; //to samo co powyzej
                    }
                    if (indexesFinished.Sum() == 0)     //gramy dopoki wszystkie plansze nie zakoncza gry - dopoki suma w liscie indeksow jest rozna od 0 czyli ujemna
                    {                                   //jesli nagle suma jest 0 to ostatnia plansza zakonczyla gre (mamy ja z foreach i mamy tez aktualnie badana liczbe)
                        CalculateScore(number, board);  //obliczamy wynik planszy ktora wygrala jako ostatnia
                        return;                         //konczymy gre
                    }
                }

            }
        }

        private void CalculateScore(int lastNumber, int[,] lastBoard)   //liczenie wyniku takie samo jak w task1
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
