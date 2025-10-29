namespace cSharpCourse.lib;
public static class TSwitch
{
    public static void Test()
    {
        //switch expression su int con relational patterns

        int a = 5;
        if (a > 0)
        {
            Console.WriteLine("Positive");
        }

        var t = a switch
        {
            > 0 => "Positive",
            < 0 => "Negative",
            _ => "Zero"
        };

        Console.WriteLine(t);

        Animal o = new Cat
        {
            Name = "Kitty",
            Age = 2,
            Species = "Felis catus"
        };

        var t2 = o switch
        {
            Cat => "It's a cat",
            Dog => "It's a dog",
            _ => "Unknown animal"
        };

        Console.WriteLine(t2);

        Animal? o2 = null;
        Console.WriteLine(NewMethod(o2));

        Animal o3 = new Dog
        {
            Name = "Buddy",
            Age = 7,
            Species = "Canis lupus familiaris"
        };

        Console.WriteLine(NewMethod(o3));

        Console.WriteLine(NewMethod(new Lion
        {
            Name = "Simba",
            Age = 4,
            Species = "Panthera leo"
        }));

        Console.WriteLine(NewMethod(new Dog
        {
            Name = "Oldie",
            Age = 12,
            Species = "Canis lupus familiaris"
        }));

        Console.WriteLine(NewMethod(new Dog
        {
            Name = "Puppy",
            Age = 3,
            Species = "Canis lupus familiaris"
        }));

        Console.WriteLine(NewMethod(new Dog
        {
            Name = "Middle",
            Age = 8,
            Species = "Canis lupus familiaris"
        }));

        Console.WriteLine(NewMethod(new Cat
        {
            Name = "Middle",
            Age = 8,
            Species = "Felis catus"
        }));


        static string NewMethod(Animal? o2)
        {
            string sound2 = o2 switch
            {
                //{ } when o2 is var x => $"{x.Name} is of type {x.GetType().Name}",
                Lion c => $"{c.GetType().Name} says roar",
                Cat c => $"{c.GetType().Name} says meow",
                { } when o2 is Dog d && d.Age < 5 => "Mini dog bark",
                { } when o2 is Dog d && d.Age > 5 && d.Age < 10 => "Middle dog bark",
                { } when o2 is Dog d && d.Age >= 10 && d.Age < 15 => "Old dog bark",
                _ => "Unknown animal sound"
            };
            return sound2;
        }
    }
}
