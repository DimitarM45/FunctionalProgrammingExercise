using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverseList = numbers =>
            {
                List<int> reversedList = new List<int>();

                for (int i = numbers.Count - 1; i >= 0; i--)
                    reversedList.Add(numbers[i]);

                return reversedList;
            };

            Func<List<int>, Predicate<int>, List<int>> excludeDivisible = (numbers, match) =>
            {
                List<int> result = new List<int>();

                foreach (int number in numbers)
                {
                    if (!match(number))
                        result.Add(number);
                }

                return result;
            };

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers = excludeDivisible(numbers, n => n % divisor == 0);

            numbers = reverseList(numbers);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
