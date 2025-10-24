using System;

namespace ConsoleApp1;

public class CarFord
{
    public string Make { get; set; } = "Ford";
    
    public void StartEngine()
    {
        Console.WriteLine($"Car Make: {Make}");
    }
}

public class Car : CarFord
{
    private int _year = 2020;

    public string Model { get; set; } = "DefaultModel";
    public int Year
    {
        get => _year;
        set
        {
            if (value > 1885) _year = value;
            else throw new ArgumentException("Year must be greater than 1885");
        }
    }

    public new void StartEngine()
    {
        Console.WriteLine($"Car Make: {Make}, Model: {Model}, Year: {Year}");
    }
}
