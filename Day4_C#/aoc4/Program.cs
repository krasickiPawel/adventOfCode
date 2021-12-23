using System;

namespace aoc4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1 task1 = new Task1(FileRead.getData());
            task1.Calculate();
            Console.Write($"Task1 result: {task1.GetResult()}");

            Console.WriteLine();

            Task2 task2 = new Task2(FileRead.getData());
            task2.Calculate();
            Console.Write($"Task2 result: {task2.GetResult()}");

        }
    }
}
