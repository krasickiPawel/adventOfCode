using System;

namespace aoc4
{
    class Program
    {   //dowiedziec sie ktora plansza wygrywa pierwsza i obliczyc jej wynik - patrz opis AoC 2021 day 4
        static void Main(string[] args)
        {
            Task1 task1 = new Task1(FileRead.getData());            //inicjalizacja task1 - podanie mu obiektu stworzonego z odczytu pliku
            task1.Calculate();                                      //obliczenie ktora plansza wygra jako pierwsza
            Console.Write($"Task1 result: {task1.GetResult()}");    //wynik == suma wszystkich liczb na planszy ktore
                                                                    //nie zostaly odkryte pomnozona przez liczbe dopiero co badana
            Console.WriteLine();

            Task2 task2 = new Task2(FileRead.getData());
            task2.Calculate();                                      //obliczenie ktora plansza wygra jako ostatnia
            Console.Write($"Task2 result: {task2.GetResult()}");

        }
    }
}
