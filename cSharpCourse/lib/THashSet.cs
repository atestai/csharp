using System;

namespace cSharpCourse.lib;

// ```markdown
// # HashSet<T> (System.Collections.Generic.HashSet<T>) — Cheatsheet

// Cheatsheet stampabile con le firme dei membri pubblici più utili di `System.Collections.Generic.HashSet<T>`. `HashSet<T>` è una collezione non-ordinata di elementi unici basata su hashing. È tipizzata e adatta per operazioni di insiemistica (union, intersect, except) e test di appartenenza ad alta prestazione.

// > Nota: le firme possono variare leggermente a seconda della versione .NET, ma questo riflette l'API tipica (.NET Core / .NET 5+ / .NET 6+).

// ---

// ## Costruttori
// ```csharp
// public HashSet();                                   // HashSet<T>()
// public HashSet(IEqualityComparer<T> comparer);
// public HashSet(IEnumerable<T> collection);          // copia da collezione (usa comparer predefinito)
// public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer);
// public HashSet(int capacity);                       // disponibile in alcune versioni per capacità iniziale
// public HashSet(int capacity, IEqualityComparer<T> comparer);
// ```

// ---

// ## Proprietà
// ```csharp
// public int Count { get; }
// public IEqualityComparer<T> Comparer { get; }
// public bool IsReadOnly { get; }                     // implementazione ICollection<T>.IsReadOnly (di solito false)
// ```

// ---

// ## Metodi principali — Aggiunta / Rimozione / Controllo
// ```csharp
// public bool Add(T item);                            // true se aggiunto, false se già presente
// public void Clear();                                // rimuove tutti gli elementi
// public bool Contains(T item);                       // O(1) medio
// public bool Remove(T item);                         // true se rimosso
// public void CopyTo(T[] array);                      // copia tutti gli elementi
// public void CopyTo(T[] array, int arrayIndex);
// public void CopyTo(T[] array, int arrayIndex, int count);
// public void TrimExcess();                           // riduce overhead interno
// ```

// ---

// ## Metodi di enumerazione e conversione
// ```csharp
// public Enumerator GetEnumerator();                  // struct enumerator (implementa IEnumerator<T>)
// IEnumerator<T> IEnumerable<T>.GetEnumerator();
// IEnumerator IEnumerable.GetEnumerator();
// public T[] ToArray();                               // disponibile come estensione LINQ: .ToArray()
// ```

// ---

// ## Operazioni insiemistiche (mutating)
// ```csharp
// public void UnionWith(IEnumerable<T> other);        // this := this ∪ other
// public void IntersectWith(IEnumerable<T> other);    // this := this ∩ other
// public void ExceptWith(IEnumerable<T> other);       // this := this \ other
// public void SymmetricExceptWith(IEnumerable<T> other); // this := (this ∪ other) \ (this ∩ other)
// ```

// ---

// ## Metodi di confronto / query insiemistiche (non-mutating / test)
// ```csharp
// public bool IsSubsetOf(IEnumerable<T> other);
// public bool IsSupersetOf(IEnumerable<T> other);
// public bool IsProperSupersetOf(IEnumerable<T> other);
// public bool IsProperSubsetOf(IEnumerable<T> other);
// public bool Overlaps(IEnumerable<T> other);         // true se esiste intersezione non vuota
// public bool SetEquals(IEnumerable<T> other);        // true se insiemi uguali (elementi identici)
// ```

// ---

// ## Metodi che restituiscono risultati di confronto (proprietà utili)
// ```csharp
// public void CopyTo(T[] array);                       // già citato
// // Non esistono TryGetValue/TryGetEquivalent nativi come in Dictionary, ma esiste:
// // public bool TryGetValue(T equalValue, out T actualValue); // disponibile in HashSet<T>
// ```
// Nota: `TryGetValue` è utile per recuperare l'istanza "memorizzata" che è considerata uguale ad un valore di lookup.

// ---

// ## Metodi e comportamenti aggiuntivi
// - Equals / GetHashCode / operatori: usa il Comparer per hash/uguaglianza degli elementi.
// - Iterazione non garantisce ordine di inserimento (a differenza di Dictionary in .NET Core che mantiene ordine d'inserimento; HashSet no).
// - HashSet usa `IEqualityComparer<T>` per hash/uguaglianza; passa un `EqualityComparer<T>.Default` se non specificato.

// ---

// ## Esempi pratici (i più usati)

// 1) Creare e aggiungere
// ```csharp
// var hs = new HashSet<int>();
// hs.Add(1);           // true
// hs.Add(2);           // true
// hs.Add(1);           // false (già presente)
// ```

// 2) Controllare presenza e rimuovere
// ```csharp
// if (hs.Contains(2)) hs.Remove(2);
// ```

// 3) Copiare elementi in array
// ```csharp
// var arr = new int[hs.Count];
// hs.CopyTo(arr);
// ```

// 4) Operazioni insiemistiche
// ```csharp
// var a = new HashSet<int> {1,2,3};
// var b = new HashSet<int> {3,4,5};

// a.UnionWith(b);      // a = {1,2,3,4,5}
// a.IntersectWith(b);  // a = {3}
// a.ExceptWith(b);     // a = {1,2}  // se a era {1,2,3}
// a.SymmetricExceptWith(b); // elementi non comuni tra a e b
// ```

// 5) Query insiemistiche
// ```csharp
// var s1 = new HashSet<int> {1,2};
// var s2 = new HashSet<int> {1,2,3,4};

// s1.IsSubsetOf(s2);   // true
// s2.IsSupersetOf(s1); // true
// s1.Overlaps(s2);     // true
// s1.SetEquals(new[]{2,1}); // true (stessi elementi, ordine non conta)
// ```

// 6) Usare TryGetValue (recuperare l'istanza memorizzata)
// ```csharp
// var hs2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Hello" };
// if (hs2.TryGetValue("hello", out var real)) {
//     // real == "Hello" (l'istanza presente nella collezione)
// }
// ```

// 7) Personalizzare uguaglianza
// ```csharp
// class Person { public string Name; public int Age; }
// var hsPerson = new HashSet<Person>(EqualityComparer<Person>.Create((a,b) => a.Name==b.Name, p => p.Name.GetHashCode()));
// ```
// (oppure implementare IEquatable<T> / override di GetHashCode/Equals sulla classe).

// ---

// ## Performance e complessità
// - Aggiunta, rimozione, contains: O(1) medio (dipende dalla qualità dell'hash).
// - Operazioni insiemistiche (UnionWith, IntersectWith...) sono generalmente O(n + m) dove n e m sono le dimensioni degli insiemi coinvolti.
// - Evitare chiavi/elementi con GetHashCode poco distribuito (collisioni degradano le prestazioni).

// ---

// ## Errori comuni e avvertenze
// - HashSet non mantiene ordine: non usarlo quando serve ordine stabile.
// - Non usare elementi mutabili come chiavi se il valore usato per GetHashCode/Equals può cambiare mentre l'elemento è nella collezione.
// - Quando confronti insiemi con comparers custom, assicurati che GetHashCode sia coerente con Equals.
// - HashSet<T> implementa ICollection<T>, quindi ha IsReadOnly = false per default; per renderlo immutabile usa wrapper o copie immutabili (ImmutableHashSet<T>).

// ---

// ## Alternative e collezioni correlate
// - SortedSet<T> — mantiene ordine (albero bilanciato), supporta operazioni di intervallo, migliori per ordini e range queries.
// - Dictionary<TKey,TValue> — quando hai bisogno di mappare chiavi a valori (valori duplicati per chiave non ammessi).
// - ConcurrentDictionary<TKey,TValue> / ImmutableHashSet<T> — per scenari concorrenti o immutabili.
// - IList<T> / List<T> — se vuoi mantenere ordine e accesso per indice.

// ---

// ## Esempio completo di utilizzo
// ```csharp
// using System;
// using System.Collections.Generic;

// var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Italy", "France" };
// set.Add("Spain");
// Console.WriteLine(set.Contains("italy")); // true

// var other = new[] { "Germany", "France" };
// set.UnionWith(other); // set ora contiene Italy, France, Spain, Germany

// foreach(var country in set)
//     Console.WriteLine(country);
// ```

// ---

// Se vuoi, posso:
// - generare un PDF da questa markdown per scaricarlo,
// - includere tutte le firme esatte tramite reflection per la versione .NET che usi (dimmi la versione .NET target),
// - o creare una cheatsheet ridotta a una pagina A4 con esempi minimi. Dimmi quale preferisci.
// ```

public static class THashSet
{

    public static void Test()
    {
        Console.WriteLine("=== THashSet Test ===");

        HashSet<string> hashSet = new HashSet<string>()
        {
            "apple",
            "banana",
            "orange"
        };

        foreach (var item in hashSet)
        {
            Console.WriteLine($"Initial item: {item}");
        }

        // Aggiunta di elementi
        hashSet.Add("apple");
        hashSet.Add("banana");
        hashSet.Add("orange");

        // Tentativo di aggiungere un elemento duplicato
        bool added = hashSet.Add("apple"); // false

        Console.WriteLine($"Added 'apple' again: {added}");

        // Verifica della presenza di un elemento
        bool containsBanana = hashSet.Contains("banana"); // true
        Console.WriteLine($"Contains 'banana': {containsBanana}");

        // Rimozione di un elemento
        hashSet.Remove("orange");

        // Iterazione sugli elementi
        Console.WriteLine("Elements in HashSet:");
        foreach (var item in hashSet)
        {
            Console.WriteLine(item);
        }
    }
}
