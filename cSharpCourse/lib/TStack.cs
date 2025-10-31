using System;

namespace cSharpCourse.lib;

// ```markdown
// # Stack<T> (System.Collections.Generic.Stack<T>) — Cheatsheet

// Cheatsheet stampabile con le firme dei membri pubblici più usati di `System.Collections.Generic.Stack<T>` e la controparte non-generic `System.Collections.Stack`. `Stack<T>` è una pila LIFO (Last-In-First-Out), utile per undo/redo, valutazione di espressioni, visite DFS, ecc.

// > Nota: preferisci `Stack<T>` (tipizzato). La versione non-generic `Stack` (System.Collections) esiste per compatibilità legacy.

// ---

// ## Costruttori (Stack<T>)
// ```csharp
// public Stack<T>();                                  // crea vuota
// public Stack<T>(int capacity);                       // crea con capacità iniziale
// public Stack<T>(IEnumerable<T> collection);          // inizializza con gli elementi (l'enumerazione è push nell'ordine dell'enumerable)
// ```

// Costruttori (non-generic Stack)
// ```csharp
// public Stack();                                     // System.Collections.Stack
// public Stack(int initialCapacity);
// public Stack(ICollection col);
// ```

// ---

// ## Proprietà
// ```csharp
// public int Count { get; }                           // numero elementi nella pila
// public bool IsReadOnly { get; }                     // implementazione ICollection<T> (di solito false)
// public object SyncRoot { get; }                     // solo su non-generic (legacy)
// public bool IsSynchronized { get; }                 // solo su non-generic
// ```

// ---

// ## Metodi principali — modifiche e accesso (Stack<T>)
// ```csharp
// public void Push(T item);                           // inserisce elemento in cima
// public T Pop();                                     // rimuove e restituisce l'elemento in cima; lancia InvalidOperationException se vuota
// public T Peek();                                    // restituisce l'elemento in cima senza rimuoverlo; lancia se vuota
// public bool TryPop(out T result);                   // non lancia, restituisce false se vuota
// public bool TryPeek(out T result);                  // non lancia, restituisce false se vuota
// public void Clear();                                // svuota la pila
// public bool Contains(T item);                       // O(n), verifica esistenza
// public void CopyTo(T[] array, int arrayIndex);      // copia snapshot nell'array (ordine: top -> bottom se iteri)
// public T[] ToArray();                               // crea array con elementi (top at index 0)
// public Enumerator GetEnumerator();                  // enumeratore struct (scorre dalla cima verso il fondo)
// IEnumerator<T> IEnumerable<T>.GetEnumerator();     // interfacce
// IEnumerator IEnumerable.GetEnumerator();
// ```

// Metodi non-generic (Stack)
// ```csharp
// public object Push(object obj);
// public object Pop();
// public object Peek();
// public void CopyTo(Array array, int index);
// public IEnumerator GetEnumerator();                 // iteratore (top -> bottom)
// public void TrimExcess();                           // riduce capacità interna (se presente)
// ```

// ---

// ## Comportamento importante e note
// - Pop/Peek sollevano InvalidOperationException se la pila è vuota. Usa TryPop/TryPeek (disponibili su Stack<T>) o verifica Count > 0.
// - L'enumerazione itera dalla cima (ultimo inserito) verso il basso (primo inserito).
// - Stack<T>.ToArray() restituisce un array con l'elemento in cima all'indice 0; utile per snapshot.
// - CopyTo copia gli elementi in base all'implementazione: verifica ordine atteso (tipicamente top -> bottom).
// - Stack<T> non è thread-safe per scritture concorrenti. Per più thread usa lock su un oggetto o strutture concorrenti custom (non esiste una ConcurrentStack<T> nella libreria base? — nella libreria `System.Collections.Concurrent` esiste `ConcurrentStack<T>` per scenari multi-thread).

// ---

// ## Operazioni e complessità
// - Push, Pop, Peek, TryPop, TryPeek: O(1) ammortizzato.
// - Contains, CopyTo: O(n).
// - ToArray: O(n) (crea snapshot).

// ---

// ## Esempi pratici (i più usati)

// 1) Creare e usare basi
// ```csharp
// var stack = new Stack<int>();
// stack.Push(1);
// stack.Push(2);
// stack.Push(3);

// int top = stack.Pop();   // 3
// int next = stack.Peek(); // 2 (senza rimuovere)
// ```

// 2) Uso sicuro senza eccezioni
// ```csharp
// if (stack.TryPop(out int value))
// {
//     Console.WriteLine($"Popped {value}");
// }
// else
// {
//     Console.WriteLine("Stack vuota");
// }
// ```

// 3) Iterare la pila (snapshot during enumeration)
// ```csharp
// foreach (var item in stack) // itera da top a bottom
//     Console.WriteLine(item);
// ```

// 4) Convertire in array (cima all'indice 0)
// ```csharp
// var arr = stack.ToArray(); // arr[0] == top
// ```

// 5) Inizializzare da collezione (attenzione all'ordine)
// ```csharp
// var list = new List<int> { 1, 2, 3 };
// var s = new Stack<int>(list); // ora s.Pop() -> 3, 2, 1
// ```

// 6) Reverse di una lista usando Stack
// ```csharp
// var s = new Stack<int>(list);
// var reversed = s.ToArray(); // array reversed rispetto a list
// ```

// 7) Uso in algoritmi (es. DFS iterativo)
// ```csharp
// var visited = new HashSet<int>();
// var stack = new Stack<int>();
// stack.Push(start);
// while (stack.Count > 0)
// {
//     var node = stack.Pop();
//     if (!visited.Add(node)) continue;
//     foreach (var neighbor in graph[node])
//         stack.Push(neighbor);
// }
// ```

// 8) Undo/Redo pattern (due stack)
// ```csharp
// var undo = new Stack<Action>();
// var redo = new Stack<Action>();

// void Do(Action doAction, Action undoAction)
// {
//     doAction();
//     undo.Push(undoAction);
//     redo.Clear();
// }

// void Undo()
// {
//     if (undo.TryPop(out var action))
//     {
//         action();
//         redo.Push(action); // spesso si salva l'azione inversa
//     }
// }
// ```

// ---

// ## ConcurrentStack<T>
// - Per scenari multi-thread preferisci `System.Collections.Concurrent.ConcurrentStack<T>`.
// - API principali: `Push`, `TryPop`, `TryPeek`, `IsEmpty`, `TryPopRange`, ecc.
// - È lock-free e progettata per alta concorrenza.

// ---

// ## Best practice
// - Usa `Stack<T>` per algoritmi LIFO semplici e locali.
// - Usa `TryPop` / `TryPeek` per evitare eccezioni in caso di pile vuote.
// - Evita di esporre direttamente la `Stack<T>` come API pubblica se vuoi conservare incapsulamento (esponi operazioni specifiche: Push, Pop, Peek).
// - Se servono operazioni concorrenti, usa `ConcurrentStack<T>` o sincronizza con `lock`.
// - Per serializzazione/uso persistente considera strutture diverse (List/Queue/Deque) a seconda dei requisiti.

//```

public static class TStack
{
    public static void Test()
    {
        var stack = new Stack<int>();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine($"Stack count after pushes: {stack.Count}");

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            Console.WriteLine($"Popped item: {item}");
        }

        Console.WriteLine($"Stack count after pops: {stack.Count}");

        // Uso sicuro senza eccezioni
        for (int i = 40; i <= 60; i += 10)
        {
            stack.Push(i);
        }

        if (stack.TryPop(out int value))
        {
            Console.WriteLine($"Popped {value}");
        }
        else
        {
            Console.WriteLine("Stack vuota");
        }

        // Iterare la pila
        Console.WriteLine("Current stack items:");

        foreach (var item in stack) // itera da top a bottom
            Console.WriteLine(item);

        // Convertire in array
        var arr = stack.ToArray(); // arr[0] == top
        Console.WriteLine("Stack as array (top at index 0):");
        foreach (var item in arr)
            Console.WriteLine(item);

        // Inizializzare da collezione
        var list = new List<int> { 1, 2, 3 };
        var s = new Stack<int>(list); // ora s.Pop() -> 3,

        Console.WriteLine("Initialized stack from list:");
        while (s.Count > 0)
        {
            Console.WriteLine(s.Pop());
        }

        // Reverse di una lista usando Stack
        var s2 = new Stack<int>(list);
        var reversed = s2.ToArray(); // array reversed rispetto a list
        Console.WriteLine("Reversed array from stack:");
        foreach (var item in reversed)
            Console.WriteLine(item);

        // Uso in algoritmi (es. DFS iterativo)
        var graph = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 2, 3 } },
            { 2, new List<int> { 4 } },
            { 3, new List<int> { 4 } },
            { 4, new List<int>() }
        };
        var visited = new HashSet<int>();
        var stackDFS = new Stack<int>();
        stackDFS.Push(1);

        Console.WriteLine("DFS traversal:");
        while (stackDFS.Count > 0)
        {
            var node = stackDFS.Pop();
            if (!visited.Add(node)) continue;
            Console.WriteLine(node);
            foreach (var neighbor in graph[node])
                stackDFS.Push(neighbor);
        }
    }
}
