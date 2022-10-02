using System;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> filter = (name, number) => 
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                    sum += name[i];

                return sum >= number ? true : false;
            };

            int number = int.Parse(Console.ReadLine());

            Func<string[], Func<string, int, bool>, string> findFirstName = (names, filter) =>
            {
                foreach (string name in names)
                {
                    if (filter(name, number))
                        return name;
                }

                return null;
            };

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(findFirstName(names, filter));
        }
    }
}
