namespace ConsoleApp1;

public record Person(string FirstName, string LastName);

internal interface ILoggable
{
    ICollection<string> ListLogs { get; }

    public void Log(string message);
}  

internal interface IEquatableAnimal<in T>
{
    bool IsEqual(T other);
}

interface IAnimal
{
    public void AnimalSound(); // interface method (does not have a body)
    public void Sleep();
    public void Eat();
}

abstract class Animal : IAnimal, IEquatableAnimal<Animal>, ILoggable // Base class (parent) 
{
    private readonly List<string> _logs = [];
    public ICollection<string> ListLogs => _logs;
    public string? Species { get; set; }
    public int Age { get; set; } = 0;
    public string? Name { get; set; }
    public virtual void AnimalSound() => Console.WriteLine("The animal makes a sound");

    public bool IsEqual(Animal other)
    {
        if (other == null) return false;
        return GetType() == other.GetType();
    }

    public virtual void Eat()
    {
        Console.WriteLine("The animal is eating");
    }

    public virtual void Sleep()
    {
        Console.WriteLine("The animal is sleeping");
    }

    public void Log(string message)
    {
        ListLogs.Add(message);
        Console.WriteLine($"Log: {message}");
    }
}

class Pig : Animal // Derived class (child) 
{
    public override void AnimalSound() => Console.WriteLine("The pig says: wee wee");
}

class Dog : Animal  // Derived class (child) 
{
    public override void AnimalSound() => Console.WriteLine("The dog says: bow wow");
    public override void Eat() => Console.WriteLine("The dog is eating bones");
}

class Cat : Animal // Derived class (child) 
{
    public override void AnimalSound()
    {
        Console.WriteLine("The cat says: meow meow");
    }

    public override void Eat()
    {
        Console.WriteLine("The cat is eating fish");
    }

    public override void Sleep()
    {
        Console.WriteLine("The cat is sleeping 12 hours a day");
    }
}

class Lion : Animal // Derived class (child) 
{
    public override void AnimalSound() => Console.WriteLine("The lion says: roar roar");
}

class Farm
{
    private string _name = "DefaultFarm";
    public string Name
    {
        get => _name;
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) _name = value;
            else throw new ArgumentException("Farm name cannot be empty");
        }
    }

    private string _location = "Unknown";
    public string Location
    {
        get => _location;
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) _location = value;
            else throw new ArgumentException("Farm location cannot be empty");
        }
    }

    private Person _owner = new("Default", "Owner");

    public Person Owner
    {
        get => _owner;
        set => _owner = value ?? throw new ArgumentNullException(nameof(value));
    }

    private readonly List<Animal> _animals = new();

    public void AddAnimal(Animal animal) => _animals.Add(animal);

    public void MakeAllSounds()
    {
        foreach (var animal in _animals)
        {
            animal.AnimalSound();
        }
    }
}
