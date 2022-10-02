using System;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> addOneToEachNumber = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                    numbers[i]++;
            };

            Action<int[]> multiplyEachNumberByTwo = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                    numbers[i] *= 2;
            };

            Action<int[]> subtractOneFromEachNumber = numbers =>
            {
                for (int i = 0; i < numbers.Length; i++)
                    numbers[i]--;
            };

            Action<int[]> printArray = numbers => Console.WriteLine(string.Join(' ', numbers));

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end") break;

                switch (input)
                {
                    case "add":
                        addOneToEachNumber(numbers);
                        break;

                    case "multiply":
                        multiplyEachNumberByTwo(numbers);
                        break;

                    case "subtract":
                        subtractOneFromEachNumber(numbers);
                        break;

                    case "print":
                        printArray(numbers);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
