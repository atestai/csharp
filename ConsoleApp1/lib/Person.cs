using System;

namespace ConsoleApp1.lib
{
    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; } = 0;
        public int Id { get; init; }

        public Person(string firstName, string lastName, int age = 0, int? id = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id ?? Random.Shared.Next();
        }
    }
}