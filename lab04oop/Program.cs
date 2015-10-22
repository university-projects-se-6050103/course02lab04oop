using System;

namespace lab04oop {
    class Program {
        public static Random Random = new Random();

        static void Main() {
            var magazine = new Magazine();

            Console.WriteLine(magazine.ToShortString());
            Console.WriteLine($"Weekly issue: {magazine[Frequency.Weekly]}");
            Console.WriteLine($"Monthly issue: {magazine[Frequency.Monthly]}");
            Console.WriteLine($"Yearly issue: {magazine[Frequency.Yearly]}");
            Console.WriteLine("\n-----\n");

            magazine.AddArticles(new Article(), new Article(new Person("Mykhaylo", "Susla", DateTime.MaxValue), "How to win at chess? 10 simple steps."));

            Console.WriteLine(magazine);
        }
    }
}
