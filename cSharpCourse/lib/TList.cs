namespace cSharpCourse.lib;

/*
    * TList class to demonstrate basic functionality.
    Nota preliminare

    Per nuovo codice preferisci List<T> rispetto a ArrayList: è tipizzato, sicuro e più performante.
    Per operazioni funzionali usa LINQ (Select, Where, Aggregate, Join, ecc.).
    Costruttori

    List<T>() — crea una lista vuota.
    List<T>(int capacity) — crea una lista con capacità iniziale.
    List<T>(IEnumerable<T> collection) — crea la lista copiando una collezione esistente.
    Proprietà / indexer

    int Capacity { get; set; } — capacità interna (allocazione).
    int Count { get; } — numero di elementi effettivi.
    T this[int index] { get; set; } — indexer (lettura/scrittura per posizione).
    bool System.Collections.Generic.ICollection<T>.IsReadOnly { get; } — implementazione interfaccia (di solito false).
    ReadOnlyCollection<T> AsReadOnly() — wrapper di sola lettura.
    Metodi (elenco completo e raggruppato) Aggiunta / inserimento

    void Add(T item)
    void AddRange(IEnumerable<T> collection)
    void Insert(int index, T item)
    void InsertRange(int index, IEnumerable<T> collection)
    Rimozione

    bool Remove(T item)
    int RemoveAll(Predicate<T> match)
    void RemoveAt(int index)
    void RemoveRange(int index, int count)
    void Clear()
    Ricerca / esistenza / indici

    int IndexOf(T item)
    int IndexOf(T item, int index)
    int IndexOf(T item, int index, int count)
    int LastIndexOf(T item)
    int LastIndexOf(T item, int index)
    int LastIndexOf(T item, int index, int count)
    bool Contains(T item)
    bool Exists(Predicate<T> match)
    T Find(Predicate<T> match)
    List<T> FindAll(Predicate<T> match)
    int FindIndex(Predicate<T> match)
    int FindIndex(int startIndex, Predicate<T> match)
    int FindIndex(int startIndex, int count, Predicate<T> match)
    T FindLast(Predicate<T> match)
    int FindLastIndex(Predicate<T> match)
    int FindLastIndex(int startIndex, Predicate<T> match)
    int FindLastIndex(int startIndex, int count, Predicate<T> match)
    Enumerazione / sottocollezioni

    Enumerator GetEnumerator() (implementa IEnumerable<T>)
    List<T> GetRange(int index, int count)
    void ForEach(Action<T> action)
    Ordinamento / ricerca binaria

    void Sort()
    void Sort(IComparer<T> comparer)
    void Sort(Comparison<T> comparison)
    void Sort(int index, int count, IComparer<T> comparer)
    int BinarySearch(T item)
    int BinarySearch(T item, IComparer<T> comparer)
    int BinarySearch(int index, int count, T item, IComparer<T> comparer) (Nota: BinarySearch richiede che la lista sia ordinata secondo lo stesso criterio usato dalla ricerca.)
    Operazioni su array / copia / conversione

    void CopyTo(T[] array)
    void CopyTo(T[] array, int arrayIndex)
    void CopyTo(int index, T[] array, int arrayIndex, int count)
    T[] ToArray()
    ReadOnlyCollection<T> AsReadOnly()
    Capacità / memoria

    void TrimExcess()
    void EnsureCapacity(int min) — disponibile nelle versioni recenti di .NET; garantisce una capacità minima.
    Altri utili

    bool TrueForAll(Predicate<T> match)
*/

public static class TList
{
    public static void Test()
    {
        Console.WriteLine("This is a test method in TList class.");

        var list = new List<int>()
        {
            2, 3, 7, 1, 3, -4, -1, 0
        };

        list.AddRange([8, 9, 5]);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        var list2 = new List<float>([6f, 3.5f, 4.2f]);
        foreach (var item in list2)
        {
            Console.WriteLine(item);
        }

        //Proprietà / indexer
        //Accesso tramite indexer e Count
        int first = list[0];   // 1
        int n = list.Count;    // 4
        list[1] = 20;          // modifica elemento in posizione 1

        Console.WriteLine($"First: {first}, Count: {n}, Modified second element: {list[1]}");


        //Cercare un elemento - predicate

        var people = new List<Person> {
            new("John", "Doe") { Id = 1, Age = 30 },
            new("Jane", "Smith") { Id = 2, Age = 25 },
            new("Alice", "Johnson") { Id = 3, Age = 17 },
            new("Bob", "Brown") { Id = 4, Age = 16 },
            new("Charlie", "Davis") { Id = 5, Age = 70 }
        };

        Console.WriteLine("People:");
        foreach (var person in people)
        {
            Console.WriteLine($"- {person.FirstName} {person.LastName}, Age: {person.Age}");
        }

        Person? p = people.Find(x => x.Id == 5);

        List<Person> minors = people.FindAll(x => x.Age < 18);
        bool anySenior = people.Exists(x => x.Age >= 65);

        if (p is not null)
        {
            Console.WriteLine($"Person with ID 5: {p.FirstName} {p.LastName}, Age: {p.Age}");
        }
        else
        {
            Console.WriteLine("Person with ID 5: Not found");
        }
        Console.WriteLine("Minors:");
        foreach (var minor in minors)
        {
            Console.WriteLine($"- {minor.FirstName} {minor.LastName}, Age: {minor.Age}");
        }
        Console.WriteLine($"Any senior (65+): {anySenior}");

        // Trovare indice e rimuovere
        int idx = list.IndexOf(20);
        if (idx >= 0)
        {
            Console.WriteLine($"20 found at index: {idx}");
            list.RemoveAt(idx);
        }
        else
            Console.WriteLine("20 not found in the list.");

        list.Remove(3);              // rimuove la prima occorrenza di 3
        int removed = list.RemoveAll(x => x < 0); // rimuove tutti i negativi

        Console.WriteLine($"Removed {removed} negative numbers.");

        Console.WriteLine("List after removals:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        //Ordinare (semplice e custom)
        var names = new List<string> { "b", "A", "c" };
        names.Sort(); // ordine lessicografico sensibile a culture
        names.Sort(StringComparer.OrdinalIgnoreCase); // comparer
        names.Sort((a, b) => b.CompareTo(a)); // lambda: ordine inverso

        Console.WriteLine("Sorted names:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        //BinarySearch (ricordati di ordinare prima)
        names.Sort();
        int pos = names.BinarySearch("A", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine($"Position of 'A': {pos}");

        //Map / Filter / Reduce con LINQ (più usato in C# moderno)

        var doubled = list.Select(x => x * 2).ToList();       // map
        var evens = list.Where(x => x % 2 == 0).ToList();     // filter
        int sum = list.Sum();                                 // reduce (somma)
        int agg = list.Aggregate((acc, x) => acc + x);        // reduce generico

        Console.WriteLine("Doubled:");
        foreach (var item in doubled)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Evens:");
        foreach (var item in evens)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Aggregate: {agg}");

        //Join in stringa
        string csv = string.Join(",", list); // "1,20,3,4" ecc.
        Console.WriteLine($"CSV: {csv}");

        //Copiare in array / ottenere array
        int[] arr = list.ToArray();
        list.CopyTo(arr, 0);
        Console.WriteLine("Array copy:");
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }

        //Operazioni con intervalli
        var part = list.GetRange(1, 2);    // sottolista (copia)
        list.InsertRange(2, new[] { 7, 8 });
        list.RemoveRange(3, 2);
        list.Reverse();
        list.Reverse(1, 3);

        Console.WriteLine("Final list:");
        foreach (var item in part)
        {
            Console.WriteLine(item);
        }


        //Iterare
        Console.WriteLine("Iterating with ForEach:");
        foreach(var x in list) Console.WriteLine(x);
        list.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("Iterating with for loop:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }

        Console.WriteLine("Iterating with LINQ:");
        foreach (var item in list.Select(x => x))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Iterating with LINQ (method syntax):");
        foreach (var item in from x in list select x)
        {
            Console.WriteLine(item);
        }

   
    }

}
