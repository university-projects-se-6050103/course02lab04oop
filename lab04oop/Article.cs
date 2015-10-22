using System;

namespace lab04oop {
    public class Article {
        public Person Person { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person person, string title) {
            Person = person;
            Title = title;
            Rating = Program.Random.Next(10, 100) * 0.214;
        }

        public Article() {
            Person = new Person("Vlad", "Golubev", new DateTime(1997, 5, 23));
            Title = "How to write a LABA. The definitive guide.";
            Rating = Program.Random.Next(10, 100) * 0.214;
        }

        public override string ToString()
        {
            return $"{Title} by {Person.ToShortString()} with rating {Rating}";
        }
    }
}