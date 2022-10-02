using System;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[], string> appendSirTitle = (names, title) => 
            {
                foreach (string name in names)
                    Console.WriteLine($"{title} {name}");
            };

            appendSirTitle(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), "Sir");
        }
    }
}
