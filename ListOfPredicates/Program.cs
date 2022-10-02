using System;
using System.Linq;
using System.Collections.Generic;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int rangeEnd = int.Parse(Console.ReadLine());

            HashSet<int> divisors = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            foreach (int divisor in divisors)
                predicates.Add(n => n % divisor == 0);

            int[] numbers = Enumerable.Range(1, rangeEnd).ToArray();

            Func<int[], List<Predicate<int>>, List<int>> filterNumbers = (numbers, predicates) =>
            {
                List<int> foundNumbers = new List<int>();

                foreach (int number in numbers)
                {
                    bool isDivisible = false;

                    foreach (Predicate<int> predicate in predicates)
                    {
                        if (predicate(number)) isDivisible = true;

                        else
                        {
                            isDivisible = false;

                            break;
                        }
                    }

                    if (isDivisible) foundNumbers.Add(number);
                }

                return foundNumbers;
            };

            List<int> filteredNumbers = filterNumbers(numbers, predicates);

            Console.WriteLine(string.Join(' ', filteredNumbers));
        }
    }
}
