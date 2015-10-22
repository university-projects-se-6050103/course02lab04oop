using System;

namespace lab04oop {
    public class Person {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public int BirthYear {
            get { return BirthDate.Year; }
            set { BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }
        }
        public DateTime BirthDate {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Person() {
            FirstName = "Vlad";
            LastName = "Golubev";
            BirthDate = new DateTime(1997, 5, 23);
        }

        public Person(string firstName, string lastName, DateTime birthDate) {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString() {
            return $"{ToShortString()} B-day: {BirthDate.ToShortDateString()}\n";
        }

        public string ToShortString() {
            return $"{FirstName} {LastName}";
        }
    }
}