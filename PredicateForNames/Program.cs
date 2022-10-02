using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, Predicate<string>, List<string>> filterNames = (names, matches) =>
            {
                List<string> filteredNames = new List<string>();

                foreach (string name in names)
                {
                    if (matches(name))
                        filteredNames.Add(name);
                }

                return filteredNames;
            };

            names = filterNames(names, n => n.Length <= nameLength);

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
