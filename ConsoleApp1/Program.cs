using System.Collections;
using System.Diagnostics;
using ConsoleApp1.lib;

namespace ConsoleApp1
{


    static class Program
    {





        static void Main(string[] args)
        {

            TestArrayList.Test();



            Cat cat = new()
            {
                Name = "Whiskers",
                Age = 3,
                Species = "Felis catus"
            };

            cat.Sleep();
            cat.AnimalSound();
            cat.Eat();

            Console.WriteLine($"Cat Name: {cat.Name}, Age: {cat.Age}, Species: {cat.Species}");

            cat.Log("Cat log entry");
            cat.Log("Another cat log entry");

            foreach (var item in cat.ListLogs)
            {
                Console.WriteLine(item);
            }


            Animal dog = new Dog();  // Create a Dog object
            dog.Sleep();
            dog.Eat();
            dog.Log("Dog log entry");

            Farm myFarm = new()
            {
                Name = "Green Farm",
                Location = "Texas",
                Owner = new Person("Alice", "Johnson")
            };
            myFarm.AddAnimal(cat);
            myFarm.AddAnimal(dog);
            myFarm.AddAnimal(new Pig());
            myFarm.AddAnimal(new Lion());
            myFarm.AddAnimal(new Lion());


            myFarm.MakeAllSounds();

            return;

            Person father = new("John", "Doe");
            Person mother = new("Jane", "Smith");
            Person kid1 = father with { FirstName = "Jimmy" };
            Person kid2 = mother with { FirstName = "Jenny" };

            Person grandpa = new("Jimmy", "Doe");

            var familyMembers = new[]
            {
                father,
                mother,
                kid1,
                kid2
            };

            foreach (var p in familyMembers)
            {
                Console.WriteLine($"Person: {p.FirstName} {p.LastName}");
            }

            Console.WriteLine($"Are the kids equal? {grandpa == kid1}");
            Console.WriteLine($"Are the kids equal? {grandpa == kid2}");

        }
    }
}
