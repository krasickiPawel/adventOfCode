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
            GameData gameData = new GameData();           //nowy obiekt odpowiadajacy za ta gre (tak naprawde przechowywane sa tu ladnie dane z pliku)             

            string file = File.ReadAllText(@"C:\Users\Paweł\Documents\studia\3 rok\AoC\day4\input4.txt");   //tu trzeba podstawic swoja sciezke
            string[] segmentedFile = file.Split("\n");    //tablica linii pliku
            string[] firstLine = segmentedFile[0].Split(",");   //pierwsza linia zamieniona na tablice "liczb" badanych - jeszcze jako stringi

            foreach (string numberAsString in firstLine)
            {
                gameData.AddNumberToBeTested(Convert.ToInt32(numberAsString));  //zamiana liczb w stringu na inty
            }

            List<string> fileLinesList = segmentedFile.ToList();                //zamiana tablicy na liste zeby wygodniej sie operowalo
            fileLinesList.RemoveAt(0);                                          //wyrzucenie licz badanych i zostawienie samych plansz

            List<string> tempList = new List<string>();                         //lista pomocnicza
            for (int i = 0; i < fileLinesList.Count; i++)                       //dla kazdej "linijki w pliku"
            {
                if (tempList.Count < 6) tempList.Add(fileLinesList[i]);         //dodajemy 6 linijek bo plansza ma 5 ale miedzy planszami sa odstepy w postaci pustych linii
                else                                                            //jesli juz uzbieramy 5 linijek z danymi
                {
                    int[,] board = new int[5, 5];                               //tablica zawierajaca liczby na planszy
                    tempList.RemoveAt(0);                                       //usuwamy pierwsza linijke w liscie ktora jest pusta                               
                    for (int j = 0; j < 5; j++)                                 //z pozostalych 5 wartosciowych linijek wyciagamy liczby i wpisujemy je do tablicy
                    {
                        var line = tempList[j].Split(" ", StringSplitOptions.RemoveEmptyEntries);   //tablica samych liczb z danej linijki (wiersza) w postaci stringow
                        for (int k = 0; k < 5; k++)
                        {
                            board[j, k] = Convert.ToInt32(line[k]);             //dla kazdej kolumny we wierszu zamieniamy string na int i zapisujemy na odpowiedniej pozycji w tablicy
                        }
                    }
                    gameData.AddBoard(board);                                   //dodajemy nowo powstala tablice bedaca plansza do danych gry
                    tempList.Clear();                                           //wyczyszczenie tempList bo zaraz bedzie kolejne 5 linijek do przebadania
                    tempList.Add(fileLinesList[i]);                             //wpisanie aktualnie badanej, nowej linijki do tempList bo inaczej bysmy ja omineli w else i dopiero kolejna dodali w if
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

            return gameData;                            //zwrocenie utworzonego obiektu gameData
        }
    }
}
