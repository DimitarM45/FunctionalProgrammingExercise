using System;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> findSmallestNumber = numbers =>
            {
                int smallestNum = int.MaxValue;

                foreach (int number in numbers)
                {
                    if (number < smallestNum)
                        smallestNum = number;
                }

                return smallestNum;
            };

            Console.WriteLine(findSmallestNumber(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()));
        }
    }
}
