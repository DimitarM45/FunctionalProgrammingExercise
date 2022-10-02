using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> doubleAttendees = (attendees, criteria) =>
            {
                List<string> attendeesCopy = new List<string>();

                for (int i = 0; i < attendees.Count; i++)
                    attendeesCopy.Add(attendees[i]);

                for (int i = 0; i < attendees.Count; i++)
                {
                    if (criteria(attendees[i]))
                        attendeesCopy.Insert(i, attendees[i]);
                }

                return attendeesCopy;
            };

            Func<List<string>, Predicate<string>, List<string>> removeAttendees = (attendees, criteria) =>
            {
                List<string> attendeesCopy = new List<string>();

                for (int i = 0; i < attendees.Count; i++)
                    attendeesCopy.Add(attendees[i]);

                for (int i = 0; i < attendees.Count; i++)
                {
                    if (criteria(attendees[i]))
                        attendeesCopy.Remove(attendees[i]);
                }

                return attendeesCopy;
            };

            List<string> attendees = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Party!")
            {
                string command = input[0];
                string criteria = input[1];
                string criteriaParameter = input[2];

                Predicate<string> predicate;

                if (criteria == "StartsWith")
                    predicate = name => name.StartsWith(criteriaParameter);

                else if (criteria == "EndsWith")
                    predicate = name => name.EndsWith(criteriaParameter);

                else
                    predicate = name => name.Length == int.Parse(criteriaParameter);

                switch (command)
                {
                    case "Double":
                        attendees = doubleAttendees(attendees, predicate);
                        break;

                    case "Remove":
                        attendees = removeAttendees(attendees, predicate);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (attendees.Count > 0)
            {
                Console.Write(string.Join(", ", attendees));
                Console.Write(" are going to the party!");
            }

            else
                Console.WriteLine("Nobody is going to the party!");
        }
    }
}
