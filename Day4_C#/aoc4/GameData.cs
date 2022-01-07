using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc4
{
    class GameData      //obiekt przechowuje "plansze" i badane liczby z podanego pliku tekstowego z danymi od advent of code (input)
    {
        public List<int> NumbersToBeTested { get; } //ciag liczb w ktorym kazda jest po kolei sprawdzana czy wystepuje na ktorejs planszy
        public List<int[,]> Boards { get; }         //plansza 5x5 liczb dosc losowych - troche lotto

        public GameData()
        {
            this.NumbersToBeTested = new List<int>();   //inicjalizacja pol (zmiennych, czyli w tym przypadku list)
            this.Boards = new List<int[,]>();           //jak widac board to tablica dwuwymiarowa, a boards to lista tablic dwuwymiarowych
        }

        public void AddBoard(int[,] board)              //dodawanie w fileRead
        {
            Boards.Add(board);
        }

        public void AddNumberToBeTested(int number)     //dodawanie w FileRead
        {
            NumbersToBeTested.Add(number);
        }
    }

}
