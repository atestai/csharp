using System;
using System.Diagnostics;

namespace ConsoleApp1.lib;

public static class TLoop
{

    public static void Test()
    {
        var stopwatch = Stopwatch.StartNew();

        // ciclo while
        int i = 0;
        while (i < 5)
        {
            Console.WriteLine($"While loop iteration: {i}");
            i++;
        }

        // ciclo do-while
        int j = 0;
        do
        {
            Console.WriteLine($"Do-While loop iteration: {j}");
            j++;
        } while (j < 5);
        

        // ciclo for
        stopwatch = Stopwatch.StartNew();
        for (int k = 0; k < 5; k++)
        {
            Console.WriteLine($"For loop iteration: {k}");
        }

        // ciclo foreach
        string[] fruits = ["Apple", "Banana", "Cherry", "Date", "Elderberry", "Fig", "Grape", "Honeydew", "Indian Fig", "Jackfruit"];
        foreach (var fruit in fruits)
        {
            Console.WriteLine($"Fruit: {fruit}");
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Foreach loop elapsed time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
