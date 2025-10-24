
using System.Collections;

namespace ConsoleApp1.lib;

public static class TestArrayList
{
    /**
        * Test method to demonstrate the usage of ArrayList.

        Elenco completo e pratico dei membri pubblici più importanti di System.Collections.ArrayList (costruttori, proprietà, indexer, metodi di istanza e metodi statici utili). Nota: alcuni metodi (Equals, GetHashCode, GetType, ToString) sono ereditati da System.Object e non li elenco qui se non specificato.

        Costruttori
        - ArrayList()
        - ArrayList(int capacity)
        - ArrayList(ICollection c)

            Proprietà e indexer
            - int Capacity { get; set; }
            - int Count { get; }
            - bool IsFixedSize { get; }
            - bool IsReadOnly { get; }
            - bool IsSynchronized { get; }
            - object SyncRoot { get; }
            - object this[int index] { get; set; }  (indexer)

            Metodi di istanza (con i principali overload)
            - int Add(object value)
            - void AddRange(ICollection c)
            - int BinarySearch(object value)
            - int BinarySearch(object value, IComparer comparer)
            - int BinarySearch(int index, int count, object value, IComparer comparer)
            - void Clear()
            - object Clone()                (da ICloneable)
            - bool Contains(object value)
            - void CopyTo(Array array)
            - void CopyTo(Array array, int arrayIndex)
            - void CopyTo(int index, Array array, int arrayIndex, int count)
            - IEnumerator GetEnumerator()
            - ArrayList GetRange(int index, int count)
            - int IndexOf(object value)
            - int IndexOf(object value, int startIndex)
            - int IndexOf(object value, int startIndex, int count)
            - void Insert(int index, object value)
            - void InsertRange(int index, ICollection c)
            - int LastIndexOf(object value)
            - int LastIndexOf(object value, int startIndex)
            - int LastIndexOf(object value, int startIndex, int count)
            - void Remove(object value)
            - void RemoveAt(int index)
            - void RemoveRange(int index, int count)
            - void Reverse()
            - void Reverse(int index, int count)
            - void Sort()
            - void Sort(IComparer comparer)
            - void Sort(int index, int count, IComparer comparer)
            - object[] ToArray()
            - Array ToArray(Type type)
            - void TrimToSize()

            Metodi statici / wrapper utili
            - Synchronized(...)  — crea un wrapper thread-safe attorno alla lista
            - FixedSize(...)     — crea un wrapper a dimensione fissa
            - ReadOnly(...)      — crea un wrapper di sola lettura

            (NB: le overload esatte e il tipo di valore restituito del wrapper possono variare — spesso le API accettano/ritornano IList o ArrayList a seconda dell'overload e della versione .NET.)

            Note rapide e consigli
            - ArrayList è non-generic (oggetti non tipizzati). Per nuovo codice preferisci List<T> (System.Collections.Generic.List<T>) per sicurezza di tipo e migliori prestazioni.
            - Per operazioni "map/filter/reduce/join" usa LINQ su IEnumerable<T> (Select, Where, Aggregate, Join, ecc.). Se hai un ArrayList, puoi convertirlo con .Cast<T>() o .OfType<T>() prima di LINQ (es. arrayList.Cast<int>().Select(...)).

            Vuoi la lista esatta dei metodi così come appaiono nella tua runtime (compresi tutti gli overload e le firme)? Posso generarla automaticamente usando reflection: incolla qui la versione target di .NET che usi (es. .NET Framework 4.8, .NET 6, .NET 7) oppure vuoi che esegua e mostri un piccolo snippet C# che stampa tutte le firme dei metodi di ArrayList?
        */

    public static void Test()
    {
        var arrayList = new ArrayList
        {
            1,
            2,
            3,
            "4",
            "5",
            "six",
            7.0,
            8.00000000001,
            new { value = "nine" },
            true
        };

    
        arrayList.AddRange(new object[] { 11, 12, 13 });
        arrayList.Insert(0, 0);
        arrayList.Remove(7.0);
        arrayList.RemoveAt(1);


        foreach (var item in arrayList)
        {
            System.Console.WriteLine(item);
        }

        var arrayList2 = ArrayList.Synchronized(arrayList);

        foreach (var item in arrayList2)
        {
            System.Console.WriteLine(item);
        }


        var arrayList3 = ArrayList.ReadOnly(arrayList);
        foreach (var item in arrayList3)
        {
            System.Console.WriteLine(item);
        }
    }

}