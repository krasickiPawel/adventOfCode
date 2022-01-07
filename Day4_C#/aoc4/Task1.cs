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
        private int score = 0;                      //szukany wynik do podania w AoC
        public Task1(GameData gameData)
        {
            this.gameData = gameData;
        }

        public void Calculate()
        {
            foreach(int number in gameData.NumbersToBeTested)   //badanie liczb po kolei czy znajduja sie na ktorejs planszy
            {
                foreach (int[,] board in gameData.Boards)       //badamy kazda plansze po kolei
                {
                    for (int i = 0; i < 5; i++)                 //badamy kazdy wiersz po kolei
                    {
                        for (int j = 0; j < 5; j++)             //badamy kazda kolumne po kolei
                        {
                            if (board[i, j] == number)          //jesli badana liczba znajduje sie na planszy to zmieniamy jej wartosc na -1
                            {                                   //bo w danych AoC nie ma liczb ujemnych (a musimy sobie jakos odrozniac ze liczba zostala odkryta)
                                board[i, j] = -1;
                            }
                        }
                    }
                }

                foreach (int[,] board in gameData.Boards)       //sprawdzanie czy ktoras plansza juz nie wygrala (wylonienie zwyciezcy)
                {
                    int[] columnSum = new int[5];               //zliczanie sumy kolumn (czy wygrana)
                    for (int i = 0; i < 5; i++)
                    {
                        int rowSum = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            rowSum += board[i, j];              //zliczanie sumy wiersza (czy wygral)
                            columnSum[j] += board[i, j];        //dodawanie do kazdej kolumny wartosci z aktualnego wiersza (coraz nizszego)
                        }
                        if (rowSum == -5)                       //sprawdzenie czy w ktoryms z wierszy jest juz zgadniete 5 liczb (warunek wygrania tej gry)
                        {
                            int total = 0;
                            for (int k = 0; k < 5; k++)         //jesli plansza wygrala to liczymy jej wynik
                                for (int l = 0; l < 5; l++)
                                    if (board[k, l] >= 0)       //bierzemy pod uwage tylko nieodkryte liczby
                                        total += board[k, l];   //zapisujemy sume nieodkrytych
                            score = total * number;             //mnozymy przez aktualnie badana liczbe i zapisujemy wynik
                            return;                             //przerwanie gry

                        }
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        if (columnSum[i] == -5)                 //sprawdzenie czy w ktorejs z kolumn jest juz zgadniete 5 liczb (warunek wygrania tej gry)
                        {
                            int total = 0;
                            for (int k = 0; k < 5; k++)
                                for (int l = 0; l < 5; l++)
                                    if (board[k, l] >= 0)
                                        total += board[k, l];   //takie samo obliczenie wyniku
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
