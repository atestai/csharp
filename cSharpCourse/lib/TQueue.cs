using System;
using System.Collections.Generic;
using System.Threading;

namespace cSharpCourse.lib;

// ```markdown
// # Queue<T> (System.Collections.Generic.Queue<T>) — Cheatsheet

// Cheatsheet stampabile con le firme dei membri pubblici più usati di `System.Collections.Generic.Queue<T>` e della controparte non-generic `System.Collections.Queue`. `Queue<T>` è una coda FIFO (First-In-First-Out), utile per gestione buffer, job scheduling, breadth-first search, producer/consumer, ecc.

// > Nota: preferisci `Queue<T>` (tipizzato). La versione non-generic `Queue` (System.Collections) è legacy.

// ---

// ## Costruttori (Queue<T>)
// ```csharp
// public Queue();                                  // Queue<T>()
// public Queue(int capacity);                       // capacità iniziale
// public Queue(IEnumerable<T> collection);          // inizializza copiando elementi (l'enumerazione inserisce in ordine)
// public Queue(int capacity, IEnumerable<T> collection); // in alcune versioni
// ```

// Costruttori (non-generic `Queue`)
// ```csharp
// public Queue();                                   // System.Collections.Queue
// public Queue(int capacity);
// public Queue(ICollection col);
// ```

// ---

// ## Proprietà
// ```csharp
// public int Count { get; }                         // numero elementi nella coda
// public bool IsReadOnly { get; }                   // da ICollection<T> (di solito false)
// public object SyncRoot { get; }                   // solo su non-generic (legacy)
// public bool IsSynchronized { get; }               // solo su non-generic
// ```

// ---

// ## Metodi principali — modifiche e accesso (Queue<T>)
// ```csharp
// public void Enqueue(T item);                      // aggiunge item in coda (tail)
// public T Dequeue();                               // rimuove e restituisce elemento in testa (head); lancia InvalidOperationException se vuota
// public T Peek();                                  // restituisce elemento in testa senza rimuoverlo; lancia se vuota
// public bool TryDequeue(out T result);             // non lancia, restituisce false se vuota
// public bool TryPeek(out T result);                // non lancia, restituisce false se vuota
// public void Clear();                              // svuota la coda
// public bool Contains(T item);                     // O(n), verifica esistenza
// public void CopyTo(T[] array, int arrayIndex);    // copia elementi in array (in ordine head->tail)
// public T[] ToArray();                             // crea array con elementi in ordine head->tail
// public Enumerator GetEnumerator();                // enumeratore struct (head -> tail)
// IEnumerator<T> IEnumerable<T>.GetEnumerator();
// IEnumerator IEnumerable.GetEnumerator();
// public void TrimExcess();                         // riduce overhead interno (se disponibile)
// ```

// Metodi non-generic (Queue)
// ```csharp
// public object Enqueue(object obj);
// public object Dequeue();
// public object Peek();
// public void CopyTo(Array array, int index);
// public IEnumerator GetEnumerator();               // iteratore head -> tail
// ```

// ---

// ## Comportamento e note importanti
// - Dequeue/Peek lanciano InvalidOperationException se la coda è vuota; preferisci TryDequeue/TryPeek per evitare eccezioni.
// - L'enumerazione scorre dall'elemento in testa (first enqueued) verso la coda (last enqueued).
// - `Queue<T>.ToArray()` restituisce snapshot della coda: l'elemento in testa sarà all'indice 0 dell'array risultante.
// - `Enqueue` è ammortizzato O(1); `Dequeue` è O(1).
// - `Contains` è O(n).
// - `Queue<T>` non è thread-safe per scritture concorrenti; per scenari concorrenti usare `ConcurrentQueue<T>`.

// ---

// ## Operazioni e complessità
// - Enqueue, Dequeue, Peek, TryDequeue, TryPeek: O(1) ammortizzato.
// - CopyTo, ToArray, Contains: O(n).

// ---

// ## Esempi pratici (i più usati)

// 1) Creare e usare coda semplice
// ```csharp
// var q = new Queue<int>();
// q.Enqueue(1);
// q.Enqueue(2);
// q.Enqueue(3);

// int head = q.Dequeue();    // 1
// int next = q.Peek();       // 2 (senza rimuovere)
// ```

// 2) Uso sicuro senza eccezioni
// ```csharp
// if (q.TryDequeue(out int value))
// {
//     Console.WriteLine($"Dequeued {value}");
// }
// else
// {
//     Console.WriteLine("Queue vuota");
// }
// ```

// 3) Iterare e snapshot
// ```csharp
// foreach (var item in q) // itera da head a tail
//     Console.WriteLine(item);

// var arr = q.ToArray(); // arr[0] == head
// ```

// 4) Inizializzare da collezione (attenzione all'ordine)
// ```csharp
// var list = new[] { 1, 2, 3 };
// var q2 = new Queue<int>(list); // Dequeue() -> 1,2,3
// ```

// 5) Producer/consumer semplice (con lock)
// ```csharp
// var q = new Queue<int>();
// var sync = new object();

// void Producer(int item)
// {
//     lock(sync)
//     {
//         q.Enqueue(item);
//         Monitor.Pulse(sync); // segnala consumer
//     }
// }

// int Consumer()
// {
//     lock(sync)
//     {
//         while (q.Count == 0) Monitor.Wait(sync);
//         return q.Dequeue();
//     }
// }
// ```

// 6) Uso in BFS (Breadth-First Search)
// ```csharp
// var queue = new Queue<int>();
// queue.Enqueue(start);
// while (queue.Count > 0)
// {
//     var node = queue.Dequeue();
//     foreach (var n in graph[node])
//         if (!visited[n])
//         {
//             visited[n] = true;
//             queue.Enqueue(n);
//         }
// }
// ```

// ---

// ## ConcurrentQueue<T>
// - Per scenari multi-thread preferisci `System.Collections.Concurrent.ConcurrentQueue<T>`.
// - API principali: `Enqueue`, `TryDequeue`, `TryPeek`, `IsEmpty`, `TryDequeueRange`, `TryPeek` ecc.
// - È lock-free e progettata per alta concorrenza. Offre anche `ToArray()` per snapshot.

// Esempio base:
// ```csharp
// var cq = new ConcurrentQueue<int>();
// cq.Enqueue(1);
// if (cq.TryDequeue(out var v)) Console.WriteLine(v);
// ```

// ---

// ## Best practice
// - Usa `TryDequeue` / `TryPeek` per evitare eccezioni su coda vuota.
// - Per buffer condivisi tra thread, preferisci `ConcurrentQueue<T>` o strutture di sincronizzazione + lock/Monitor.
// - Evita di esporre direttamente `Queue<T>` in API pubbliche se vuoi controllare invarianti; espone solo operazioni necessarie.
// - Usa `TrimExcess` dopo grandi consumi per ridurre l'overhead interno (se disponibile nella runtime).

public static class TQueue
{

    public static void Test()
    {
        // Example usage of Queue<T>
        var q = new Queue<int>();
        q.Enqueue(1);
        q.Enqueue(2);
        q.Enqueue(3);

        int head = q.Dequeue();    // 1
        int next = q.Peek();       // 2 (senza rimuovere)

        Console.WriteLine($"Head: {head}, Next: {next}");

        // Example usage of TryDequeue
        if (q.TryDequeue(out int value))
        {
            Console.WriteLine($"Dequeued {value}");
        }
        else
        {
            Console.WriteLine("Queue vuota");
        }

        // Iterating through the queue
        foreach (var item in q) // itera da head a tail
            Console.WriteLine(item);

        // Creating an array snapshot of the queue
        var arr = q.ToArray(); // arr[0] == head
        Console.WriteLine("Array snapshot of queue:");

        foreach (var item in arr)
            Console.WriteLine(item);

        // Initializing from a collection
        var list = new[] { 1, 2, 3 };
        var q2 = new Queue<int>(list); // Dequeue() -> 1,
        Console.WriteLine("Dequeuing from initialized queue:");
        while (q2.Count > 0)
        {
            Console.WriteLine(q2.Dequeue());
        }

        // Note: Further examples like producer/consumer and BFS can be implemented similarly.
        // Producer/Consumer example
        var queue = new Queue<int>();
        var sync = new object();

        void Producer(int item)
        {
            lock (sync)
            {
                queue.Enqueue(item);
                Monitor.Pulse(sync); // segnala consumer
                Console.WriteLine($"Produced: {item}");
            }
        }

        int Consumer()
        {
            lock (sync)
            {
                while (queue.Count == 0) Monitor.Wait(sync);
                return queue.Dequeue();
            }
        }

        // Note: In real applications, Producer and Consumer would run in separate threads.

        foreach (var item in new[] { 23, 34, 566, 78, 89 })
        {
            Producer(item);
            Producer(item + 1);

            Console.WriteLine($"Consumed: {Consumer()}");
            Console.WriteLine($"Consumed: {Consumer()}");
        }

        // BFS example can be added similarly if needed.

        var bfsQueue = new Queue<int>();
        bfsQueue.Enqueue(0);
        
        var visited = new HashSet<int> { 0 };
        Console.WriteLine("BFS Example:");
        
        while (bfsQueue.Count > 0 && visited.Count < 1000)
        {
            var node = bfsQueue.Dequeue();
            Console.WriteLine($"Visiting node: {node}");
            // Simulate neighbors
            for (int neighbor = node + 1; neighbor <= node + 2; neighbor++)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    bfsQueue.Enqueue(neighbor);
                }
            }
        }
    }
}
