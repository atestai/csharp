using System;

namespace cSharpCourse.lib;

// ```markdown
// # Dictionary<TKey, TValue> (System.Collections.Generic.Dictionary<TKey,TValue>) — Cheatsheet

// Cheatsheet stampabile con le firme dei membri pubblici più utili di `System.Collections.Generic.Dictionary<TKey, TValue>`. `Dictionary` è una mappa tipizzata chiave→valore basata su hashing, con ottime prestazioni per lookup, inserimento e rimozione.

// > Nota: le firme riflettono l'API tipica in .NET Core / .NET 5+ / .NET 6+. Alcuni overload potrebbero variare tra versioni.

// ---

// ## Costruttori
// ```csharp
// public Dictionary();
// public Dictionary(int capacity);
// public Dictionary(IEqualityComparer<TKey> comparer);
// public Dictionary(IDictionary<TKey, TValue> dictionary);
// public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer);
// public Dictionary(int capacity, IEqualityComparer<TKey> comparer);
// public Dictionary(IEnumerable<KeyValuePair<TKey,TValue>> collection);         // in alcune versioni
// ```

// ---

// ## Proprietà
// ```csharp
// public int Count { get; }
// public TValue this[TKey key] { get; set; }                 // indexer: get => KeyNotFoundException se chiave assente; set => aggiunge/sovrascrive
// public IEqualityComparer<TKey> Comparer { get; }
// public ICollection<TKey> Keys { get; }                     // view sulle chiavi
// public ICollection<TValue> Values { get; }                 // view sui valori
// public bool IsReadOnly { get; }                            // da ICollection<KeyValuePair<TKey,TValue>>
// ```

// ---

// ## Metodi principali — Inserimento / Aggiornamento / Rimozione
// ```csharp
// public void Add(TKey key, TValue value);                   // lancia ArgumentException se la chiave esiste già
// public bool Remove(TKey key);                              // true se rimosso
// public bool TryGetValue(TKey key, out TValue value);       // safe lookup: evita eccezioni
// public bool ContainsKey(TKey key);
// public bool ContainsValue(TValue value);                   // ricerca lineare sui valori (O(n))
// public void Clear();
// public TValue GetValueOrDefault(TKey key);                 // in .NET Core / .NET 5+ (opzionale overload con default value)
// public TValue GetValueOrDefault(TKey key, TValue defaultValue);
// ```

// ---

// ## Metodi e operazioni su coppie
// ```csharp
// public void Add(KeyValuePair<TKey, TValue> item);          // da ICollection<KeyValuePair<,>>
// public bool Remove(KeyValuePair<TKey, TValue> item);       // da ICollection<KeyValuePair<,>>
// public bool TryAdd(TKey key, TValue value);                // disponibile in .NET Core 2.0+ (non lancia se esiste)
// public void CopyTo(KeyValuePair<TKey,TValue>[] array, int arrayIndex);
// public void EnsureCapacity(int capacity);                  // aumenta la capacità interna (versioni recenti)
// public void TrimExcess();                                  // riduce overhead
// ```

// ---

// ## Enumerazione e conversione
// ```csharp
// public Enumerator GetEnumerator();                         // struct enumerator su KeyValuePair<TKey,TValue>
// IEnumerator<KeyValuePair<TKey,TValue>> IEnumerable<KeyValuePair<TKey,TValue>>.GetEnumerator();
// IEnumerator IEnumerable.GetEnumerator();
// public Dictionary<TKey,TValue>.ValueCollection Values { get; }  // già citato
// public Dictionary<TKey,TValue>.KeyCollection Keys { get; }      // già citato
// public KeyValuePair<TKey,TValue>[] ToArray()                 // via LINQ: .ToArray()
// ```

// ---

// ## Metodi per merging e trasformazioni
// ```csharp
// public void CopyTo(KeyValuePair<TKey,TValue>[] array, int arrayIndex); // copia coppie chiave/valore
// // Merge pattern (non built-in un unico metodo): usare foreach + TryAdd / indexer per sovrascrittura controllata
// ```

// ---

// ## Performance e complessità
// - Accesso, inserimento, rimozione, ContainsKey, TryGetValue: O(1) medio (dipende dalla qualità dell'hash).
// - ContainsValue: O(n).
// - Evitare chiavi mutabili che cambino hash/uguaglianza mentre sono nella Dictionary.
// - Use EnsureCapacity per preallocare quando si conosce la dimensione per evitare rehash multipli.

// ---

// ## Esempi pratici (i più usati)

// 1) Creare e aggiungere
// ```csharp
// var dict = new Dictionary<string,string>();
// dict.Add("IT", "Italy");            // lancia se "IT" già presente
// dict["FR"] = "France";              // aggiunge o sovrascrive
// ```

// 2) Lookup sicuro con TryGetValue
// ```csharp
// if (dict.TryGetValue("IT", out var country))
// {
//     Console.WriteLine(country);
// }
// else
// {
//     Console.WriteLine("Not found");
// }
// ```

// 3) Verificare esistenza e rimozione
// ```csharp
// if (dict.ContainsKey("DE")) dict.Remove("DE");
// ```

// 4) Iterare chiavi/valori
// ```csharp
// foreach (var kvp in dict)
// {
//     Console.WriteLine($"{kvp.Key} => {kvp.Value}");
// }

// // Solo chiavi o valori
// foreach (var key in dict.Keys) { }
// foreach (var value in dict.Values) { }
// ```

// 5) Usare TryAdd per evitare eccezioni
// ```csharp
// if (!dict.TryAdd("ES", "Spain"))
// {
//     // chiave esistente
//     dict["ES"] = "Spain"; // o altra gestione
// }
// ```

// 6) Merge di due dictionary (sovrascrittura con indexer)
// ```csharp
// var src = new Dictionary<string,int> { ["a"] = 1, ["b"] = 2 };
// var dest = new Dictionary<string,int> { ["b"] = 10, ["c"] = 3 };
// foreach (var kv in src) dest[kv.Key] = kv.Value; // dest: a=1, b=2, c=3 (sovrascrive b)
// ```

// 7) Creare Dictionary da IEnumerable
// ```csharp
// var items = new[] { ("a",1), ("b",2) };
// var dictFromEnumerable = items.ToDictionary(t => t.Item1, t => t.Item2);
// ```

// 8) TryGetValue con default esplicito (GetValueOrDefault)
// ```csharp
// var val = dict.GetValueOrDefault("XX", "default");
// ```

// ---

// ## Thread-safety
// - Dictionary non è thread-safe per scritture concorrenti.
// - Per sola lettura dopo popolamento in sicurezza multi-thread si può condividere senza lock.
// - Per scenari concorrenti usa `ConcurrentDictionary<TKey,TValue>`.

// ---

// ## Suggerimenti pratici e best practices
// - Preferire TryGetValue anziché ContainsKey + indexer per evitare doppio lookup.
// - Quando possibile usare tipi immutabili come chiavi (string, int, record immutabili).
// - Override GetHashCode/Equals o implementare IEquatable<T> per tipi custom usati come chiave.
// - Usare EqualityComparer<TKey>.Default o passare un IEqualityComparer personalizzato (es. StringComparer.OrdinalIgnoreCase per stringhe case‑insensitive).
// - Usare EnsureCapacity se si conosce la dimensione attesa per ridurre riallocazioni.
// - Per mantenere ordine di inserimento usare `OrderedDictionary` (System.Collections.Specialized) o sfruttare che `Dictionary` in .NET Core 2.1+ mantiene l'ordine di inserimento, ma non fare affidamento per algoritmi critici se la versione target non lo garantisce.

// ---

// ## Errori comuni
// - Chiamare Add con chiave già presente -> ArgumentException.
// - Usare elementi mutabili come chiavi e poi modificarne i campi che influenzano GetHashCode/Equals.
// - Confondere ContainsValue (costo O(n)) con ContainsKey (O(1)).
// - Aspettarsi ordine prevedibile in enumerazione (a meno di versioni/contratti specifici).

// ---

// ## Esempio completo
// ```csharp
// using System;
// using System.Collections.Generic;

// var dict = new Dictionary<string,int>(StringComparer.OrdinalIgnoreCase)
// {
//     ["IT"] = 1,
//     ["FR"] = 2
// };
// dict.TryAdd("ES", 3);
// if (dict.TryGetValue("it", out var val)) Console.WriteLine(val); // case-insensitive thanks to comparer

// foreach (var kv in dict)
//     Console.WriteLine($"{kv.Key} -> {kv.Value}");
// ```

// ---

// Se vuoi, posso:
// - convertire la tua classe THashTable.Test ad usare Dictionary<string,string> e mostrare le differenze,
// - generare un PDF da questa markdown,
// - o estrarre le firme esatte tramite reflection per la versione .NET che usi (dimmi la versione).  
// Dimmi quale preferisci.
// ```

public static class TDictionary
{

    public static void Test()
    {
        var dictionary = new Dictionary<string, int>
            {
                { "One", 1 },
                { "Two", 2 },
                { "Three", 3 }
            };

        Console.WriteLine($"Initial count: {dictionary.Count}");

        dictionary["Four"] = 4;
        dictionary["Five"] = 5;

        foreach (var kvp in dictionary)
        {
            Console.WriteLine(kvp);
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        foreach (KeyValuePair<string, int> item in dictionary)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        dictionary.Remove("One");
        if (dictionary.TryGetValue("Two", out var value))
        {
            Console.WriteLine($"Value for 'Two': {value}");
        }

        Console.WriteLine($"Final count: {dictionary.Count}");

        dictionary.Clear();

        Console.WriteLine($"Count after clear: {dictionary.Count}");

        // Additional examples
        if (!dictionary.TryAdd("Six", 6))
        {
            Console.WriteLine("Key 'Six' already exists.");
        }
        Console.WriteLine($"Count after TryAdd: {dictionary.Count}");

        var keys = dictionary.Keys;
        var values = dictionary.Values;

        Console.WriteLine("Keys:");
        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }
        Console.WriteLine("Values:");
        foreach (var val in values)
        {
            Console.WriteLine(val);
        }
    }
}
