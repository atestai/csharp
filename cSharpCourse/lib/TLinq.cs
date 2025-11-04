using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace cSharpCourse.lib;

// LINQ — concetti rapidi

// - LINQ opera su IEnumerable<T> / IQueryable<T>. Per List<T> puoi usare LINQ direttamente (using System.Linq).
// - Method syntax (estensioni: Where, Select, etc.) è la più usata; Query syntax (from ... in ...) è più leggibile per query complesse.
// - LINQ è lazy: le query non vengono eseguite fino a quando non si enumerano (ToList, ToArray, foreach, ecc.).
// - Per collezioni non-generic puoi usare .Cast<T>() o .OfType<T>() per ottenere IEnumerable<T>.

// Metodi LINQ più usati (che conviene ricordare)

// -- Where(Func<T,bool>) — filtra (equivalente a filter in JS)
// -- Select(Func<T,TR>) — proiezione / map
// -- SelectMany(Func<T,IEnumerable<R>>) — appiattisce sequence di sequence
// -- OrderBy / OrderByDescending / ThenBy / ThenByDescending — ordinamento
// -- GroupBy(Func<T,Key>) — raggruppamento
// -- Join / GroupJoin — join tra collezioni (come SQL)
// -- Distinct() — rimuove duplicati (usa default comparer o overload con comparer)
// -- Take(n) / Skip(n) — paginazione
// -- First / FirstOrDefault / Single / SingleOrDefault — estrazione di un singolo elemento
// -- Any(Func<T,bool>) / All(Func<T,bool>) — predicati di esistenza/tutti
// -- Count() / Count(Func<T,bool>)
// -- Sum / Min / Max / Average — aggregazioni numeriche
// -- Aggregate(seed, func) — reduce/fold generico
// -- ToList() / ToArray() / ToDictionary(keySelector, valueSelector)
// -- AsEnumerable() / AsQueryable() — switch tra IEnumerable e IQueryable
// -- OfType<T>() / Cast<T>() — conversione da non-generic a generic
// -- TakeWhile / SkipWhile — basati su condizione
// -- Zip — combina due sequenze elemento per elemento
// -- ToLookup — come GroupBy ma restituisce lookup
public class TLinq
{

    private List<int> Numbers { get; } = [1, 2, 3, 4, 5, 6, 7, 8, 9, 34, 90, 23, 45, 67, 89];
    //private List<int> Numbers2 { get; } = [5, 6, 7, 8, 9, 10, 11, 12];
    

    public void MethodSyntax()
    {
        // Esempio di Method Syntax

        IEnumerable<int> oddNumbers = Numbers.Where(n => n % 2 != 0);
        Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));

        List<int> oddList = [.. oddNumbers];
        Console.WriteLine("Odd Numbers List: " + string.Join(", ", oddList));
    }


    public void QuerySyntax()
    {
        // Esempio di Query Syntax

        var oddNumbers =
            from n in Numbers
            where n % 2 != 0
            select n;

        Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));

        List<int> oddList = [.. oddNumbers];
        Console.WriteLine("Odd Numbers List: " + string.Join(", ", oddList));
    }


    public void MapSyntax()
    {
        var squaredNumbers = Numbers.Where(n => n % 2 == 0).Select(n => n * n);
        Console.WriteLine("Squared Numbers: " + string.Join(", ", squaredNumbers));
    }
    

    public static void Test()
    {
        Console.WriteLine("TLinq Running...");

        var instance = new TLinq();
        Console.WriteLine("list: " + string.Join(", ", instance.Numbers));


        Console.WriteLine("Method Syntax:");
        instance.MethodSyntax();

        Console.WriteLine("Query Syntax:");
        instance.QuerySyntax();

        Console.WriteLine("Map Syntax:");
        instance.MapSyntax();

        // Esempio di Parallel LINQ (PLINQ)
        var largeNumbers = Enumerable.Range(1, 1_000_000);
        var oddParallel = largeNumbers.AsParallel().Where(n => (n & 1) == 0).ToList();
        Console.WriteLine("Odd Numbers in Parallel: " + string.Join(", ", oddParallel.Take(10)) + " ...");


        int oddCount = instance.Numbers.Count(n => n % 2 != 0);
        Console.WriteLine("Count of Odd Numbers: " + oddCount);

        int oddSum = instance.Numbers.Where(n => n % 2 != 0).Sum();
        Console.WriteLine("Sum of Odd Numbers: " + oddSum);

        int firstOdd = instance.Numbers.FirstOrDefault(n => n % 2 != 0); // 0 se nessuno
        Console.WriteLine("First Odd Number: " + firstOdd);

        var uniqueOdds = instance.Numbers.Where(n => n % 2 != 0).Distinct();
        Console.WriteLine("Unique Odd Numbers: " + string.Join(", ", uniqueOdds));

        Console.WriteLine("TLinq Finished.");
    }
}

