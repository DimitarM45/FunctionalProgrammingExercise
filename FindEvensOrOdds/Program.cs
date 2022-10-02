using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
                numbers.Add(i);

            if (evenOrOdd == "even")
                Console.WriteLine(string.Join(' ', numbers.FindAll(isEven)));

            else
                Console.WriteLine(string.Join(' ', numbers.FindAll(isOdd)));
        }
    }
}
