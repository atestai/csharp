using System.Collections;

namespace cSharpCourse.lib;

// > Nota: `Hashtable` è non-generic (chiavi/valori come `object`). Per nuovo codice preferire `Dictionary<TKey,TValue>` o `ConcurrentDictionary<TKey,TValue>`.

// ---

// ## Costruttori
// ```csharp
// public Hashtable(); 
// public Hashtable(int capacity);
// public Hashtable(IDictionary d);
// public Hashtable(int capacity, float loadFactor);
// public Hashtable(IHashCodeProvider hcp, IComparer comparer);        // legacy (non comuni in .NET Core)
// public Hashtable(IEqualityComparer equalityComparer);              // in alcune implementazioni / versioni
// public Hashtable(int capacity, IEqualityComparer equalityComparer);
// public Hashtable(IDictionary d, IEqualityComparer equalityComparer);
// public Hashtable(int capacity, float loadFactor, IEqualityComparer equalityComparer);
// ```

// ---

// ## Proprietà
// ```csharp
// public virtual int Count { get; }
// public virtual ICollection Keys { get; }
// public virtual ICollection Values { get; }
// public virtual bool IsReadOnly { get; }
// public virtual bool IsFixedSize { get; }
// public virtual bool IsSynchronized { get; }
// public virtual object SyncRoot { get; }
// public virtual object this[object key] { get; set; }   // indexer
// ```

// ---

// ## Metodi principali — Inserimento / Aggiornamento / Rimozione
// ```csharp
// public virtual void Add(object key, object value);
// public virtual void Clear();
// public virtual bool Contains(object key);              // alias ContainsKey semantics
// public virtual bool ContainsKey(object key);           // presente in alcune versioni/compatibilità
// public virtual bool ContainsValue(object value);
// public virtual void Remove(object key);
// public virtual void Remove(object key, out object value); // non standard, verificare runtime (legacy)
// public virtual void CopyTo(Array array, int arrayIndex); // copia DictionaryEntry o object[] a seconda del tipo array
// public virtual object Clone();                         // shallow copy
// ```

// ---

// ## Metodi di enumerazione e accesso
// ```csharp
// public virtual IDictionaryEnumerator GetEnumerator(); // restituisce IDictionaryEnumerator (Current: DictionaryEntry)
// public virtual IEnumerator GetEnumerator(bool returnKeys); // legacy: varia per implementazioni
// public virtual ICollection Keys { get; }               // proprietà vista sopra
// public virtual ICollection Values { get; }             // proprietà vista sopra
// ```

// ---

// ## Metodi di sincronizzazione e utilità
// ```csharp
// public static IDictionary Synchronized(Hashtable table);  // ritorna wrapper thread-safe come IDictionary
// public virtual void TrimToSize();                         // riduce la capacità interna al Count
// public virtual void CopyTo(Array array, int index);       // alias, copia entries
// ```

// ---

// ## Note su overload / comportamento
// - `Add(object key, object value)` lancia `ArgumentException` se la chiave esiste già.
// - L'indexer `this[object key]` con `set` sovrascrive senza lanciare eccezione; con `get` restituisce `null` se la chiave non esiste.
// - `Contains` verifica l'esistenza della chiave; `ContainsValue` esegue ricerca lineare sui valori (costo O(n)).
// - `Clone()` effettua shallow copy: la nuova `Hashtable` conterrà riferimenti agli stessi oggetti chiave/valore.
// - L'iterazione con `foreach` su una `Hashtable` restituisce `DictionaryEntry`:
//   ```csharp
//   foreach (DictionaryEntry e in hashtable)
//   {
//       var key = e.Key;
//       var value = e.Value;
//   }
//   ```
// - `CopyTo` richiede che l'array di destinazione sia correttamente tipizzato (`DictionaryEntry[]` o `object[]` a seconda dell'implementazione e dell'uso).

// ---

// ## Esempi rapidi d'uso

// - Creazione e aggiunta:
// ```csharp
// var ht = new Hashtable();
// ht.Add("Sicilia", "Palermo");
// ht["Lazio"] = "Roma";    // aggiunge o sovrascrive
// ```

// - Controllo ed accesso:
// ```csharp
// if (ht.Contains("Puglia"))
// {
//     var val = ht["Puglia"];
// }
// ```

// - Iterazione:
// ```csharp
// foreach (DictionaryEntry de in ht)
//     Console.WriteLine($"{de.Key} -> {de.Value}");
// ```

// - Rimozione:
// ```csharp
// ht.Remove("Molise");
// ```

// - Copia superficiale:
// ```csharp
// var copy = (Hashtable)ht.Clone();
// ```

// - Wrapper thread-safe:
// ```csharp
// var sync = Hashtable.Synchronized(ht); // restituisce IDictionary sincronizzato
// lock(ht.SyncRoot) { /* operazioni atomiche multiple */ }
// ```

// ---

// ## Conversione a collezioni tipizzate
// ```csharp
// var dict = new Dictionary<string, string>();
// foreach (DictionaryEntry e in ht)
// {
//     if (e.Key is string k && e.Value is string v)
//         dict[k] = v;
// }
// ```

// ---

// ## Raccomandazioni pratiche
// - Preferire `Dictionary<TKey,TValue>` per nuovo codice (tipizzato, `TryGetValue`, migliori prestazioni).
// - Per scenari concorrenti usare `ConcurrentDictionary<TKey,TValue>`.
// - Se serve ordine di inserimento usare `OrderedDictionary` (System.Collections.Specialized) o `Dictionary<TKey,TValue>` su .NET Core 2.1+ (mantiene ordine di inserimento).
// - Evitare chiavi mutabili: le chiavi dovrebbero avere `GetHashCode()` stabile e `Equals()` coerente.
// - `Hashtable` accetta chiavi/valori eterogenei (object), ma ciò può aumentare la possibilità di errori di cast e costi di boxing/unboxing.

// ---

// Se vuoi, posso generare un PDF o un file stampabile (Markdown -> PDF) con questa cheatsheet, oppure includere tutte le firme esatte recuperate via reflection dalla tua runtime .NET (se mi dici la versione .NET target: ex. .NET Framework 4.8, .NET 6, .NET 7).  


public static class THashTable
{

    public static void Test()
    {
        Console.WriteLine("THashTable Test method called.");
        // Add your test code here

        var hashTable = new Hashtable()
        {
            {"Sicilia", "palermo"},
            {"Campania", "napoli"},
            {"Lazio", "roma"},
            {"Puglia", "bari"},
            {1, "One"},
            {2, "Two"}
        };

        foreach (DictionaryEntry item in hashTable)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        hashTable.Add("Calabria", "catanzaro");
        hashTable.Add("Basilicata", "potenza");
        hashTable.Add("Molise", "campobasso");

        foreach (DictionaryEntry item in hashTable)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        // Accessing elements
        Console.WriteLine($"The capital of Sicilia is {hashTable["Sicilia"]}");
        Console.WriteLine($"The capital of Campania is {hashTable["Campania"]}");


        // Removing an element
        hashTable.Remove("Molise");
        Console.WriteLine("After removing Molise:");
        foreach (DictionaryEntry item in hashTable)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }

        hashTable.Clear();
        Console.WriteLine($"Count after clearing: {hashTable.Count}");

        
    }
}
