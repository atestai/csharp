using System;

namespace ConsoleApp1.lib;

public static class TSwitch
{
    public static void Test()
    {
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

        // Animal o2 = new Dog
        // {
        //     Name = "Buddy",
        //     Age = 21,
        //     Species = "Canis lupus familiaris"
        // };

        // string sound2 = o2 switch
        // {
        //     { } when o2 is Lion c => $"{c.GetType().Name} says roar",
        //     Cat c => $"{c.GetType().Name} says meow",
        //     Dog d when d.Age > 5 => "old dog bark",
        //     _ => "unknown"
        // };
        // Console.WriteLine(sound2);

        Animal? o2 = null;

        string sound2 = o2 switch
        {
            //{ } when o2 is var x => $"{x.Name} is of type {x.GetType().Name}",
            Lion c => $"{c.GetType().Name} says roar",
            Cat c => $"{c.GetType().Name} says meow",
            { } when o2 is Dog d && d.Age < 5 => "mini dog bark",
            { } when o2 is Dog d && d.Age > 5 && d.Age < 10 => "middle dog bark",
            { } when o2 is Dog d && d.Age >= 10 && d.Age < 15 => "old dog bark",
            _ => "unknown"
        };

        Console.WriteLine(sound2);

        {
            if (o2 is Dog d && d.Age < 5)
            {
                sound2 = "mini dog bark";
            }
            else if (o2 is Dog d2 && d2.Age >= 5 && d2.Age < 10)
            {
                sound2 = "middle dog bark";
            }
            else if (o2 is Dog d3 && d3.Age >= 10 && d3.Age < 15)
            {
                sound2 = "old dog bark";
            }
            else
            {
                sound2 = "unknown";
            }

            Console.WriteLine(sound2);
        }
    }
}
