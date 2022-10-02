using System;

namespace ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
