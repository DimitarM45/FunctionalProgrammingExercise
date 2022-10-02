using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> filterAttendeeList = (attendees, predicate) =>
            {
                List<string> attendeesCopy = new List<string>();

                foreach (string attendee in attendees)
                {
                    if (!predicate(attendee))
                        attendeesCopy.Add(attendee);
                }

                return attendeesCopy;
            };

            List<string> attendees = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string[] tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            while (tokens[0] != "Print")
            {
                string action = tokens[0];
                string filter = tokens[1];
                string filterParameter = tokens[2];

                GetPredicate(filter, filterParameter);

                switch (action)
                {
                    case "Add filter":
                        filters.Add(filter + filterParameter, GetPredicate(filter, filterParameter));
                        break;

                    case "Remove filter":
                        filters.Remove(filter + filterParameter);
                        break;

                    default:
                        break;
                }

                tokens = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var (filterId, filter) in filters)
                attendees = filterAttendeeList(attendees, filter);

            Console.WriteLine(string.Join(' ', attendees));
        }

        static Predicate<string> GetPredicate(string filter, string filterParameter)
        {
            switch (filter)
            {
                case "Starts with":
                    return name => name.StartsWith(filterParameter);

                case "Ends with":
                    return name => name.EndsWith(filterParameter);

                case "Length":
                    return name => name.Length == int.Parse(filterParameter);

                case "Contains":
                    return name => name.Contains(filterParameter);

                default:
                    return default(Predicate<string>);
            }
        }
    }
}
