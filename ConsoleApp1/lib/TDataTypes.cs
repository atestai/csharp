using System;

namespace ConsoleApp1.lib;

/*
    This class demonstrates the use of various data types in C#,
    including primitive types, object types, var, dynamic, and a custom record type.

    Tipi di variabili e literal suffix

    int myInt = 42;
    int è alias di System.Int32. Valori interi a 32 bit.

    long myLong = 1234567890123456789L;
    long = System.Int64 (64 bit). La L finale indica che il literal è di tipo long. (Il valore nel tuo esempio è valido per Int64.)

    float myFloat = 35e1F;
    float = System.Single (32 bit). 35e1 significa 35 × 10^1 = 350.0. La F o f obbligatoria indica float (altrimenti il literal a virgola mobile è double).

    double myDouble = 42.0D;
    double = System.Double (64 bit). La D è opzionale (i literal floating senza suffix sono double per default).

    decimal myDecimal = 99.99m;
    decimal = System.Decimal, tipo a precisione elevata per moneta/finanza. La m o M è obbligatoria per i literal decimal.

    bool myBoolean = true;
    booleano true/false.

    Stringhe e caratteri
    string myString = "Hello, W'orld!";
    Le stringhe in C# sono delimitate da doppi apici. L'apice singolo (') non va scappato in una stringa con doppi apici. Per includere doppi apici dentro la stringa si usa " oppure stringa verbatim @.

    Oggetto anonimo e boxing
    - object myObject = new { Property1 = "Value1", Property2 = 123 };
        new { ... } è un anonymous type (tipo anonimo). Lo assegni a object: il valore viene boxed/reference typed in object. Se fai Console.WriteLine(myObject) verrà chiamato il ToString generato per il tipo anonimo, ad esempio "{ Property1 = Value1, Property2 = 123 }".
    - Se vuoi usare le proprietà dell'oggetto anonimo devi tenerlo come var (var a = new { ... }) per poter accedere a a.Property1 (ma il tipo rimane anonimo, accessibile solo nel medesimo scope).
    
    
    var vs dynamic
    var myVar = "I am a var type";

    var è inferenza statica del tipo a compile time: myVar è una stringa e rimane una stringa. Non è "tipaggio dinamico".
    dynamic myDynamic = "I am a dynamic type";
    dynamic è risolto a runtime: il compilatore non verifica i membri/operazioni. Puoi riassegnare myDynamic = 100; senza errori di compilazione. Attenzione: gli errori di chiamata di metodi/proprietà su dynamic emergono solo a runtime.
    

    Esempi con Person (overload, object initializer, named argument)
    var person = new Person("Alice", "Johnson", 30, 1);

    Chiama un costruttore con (firstName, lastName, age, id).
    var anotherPerson = new Person("Bob", "Smith") { Age = 25 };

    Chiamata a un costruttore (forse con solo first/last) e poi uso di object initializer per impostare Age. Sintassi equivalente a: var p = new Person("Bob","Smith"); p.Age = 25;
    var anotherPersonWithId = new Person("Charlie", "Brown", id: 42);

    Uso di named argument: passi solo id (gli altri parametri o hanno valori di default o esistono overload che lo permettono).
    var yetAnotherPerson = new Person("David", "Wilson", 40);

    Sembra chiamare costruttore (first, last, age).
    Console.WriteLine e string interpolation

    Console.WriteLine($"Integer: {myInt}");
    Interpolazione di stringa ($"..."): dentro { } puoi inserire espressioni. È il modo più leggibile per comporre output.
    Quando metti {myObject} viene invocato myObject?.ToString() per ottenere la rappresentazione stringa.
    Comportamento dinamico

    myDynamic = 100;
    È una riassegnazione valida: dynamic non impone il tipo statico. Operazioni successive su myDynamic saranno risolte a runtime.
    Boxing/Unboxing e implicazioni

    Assegnare un anonymous type a object o assegnare tipi valore (int, long, ecc.) a object implica boxing per i value type. Il boxing ha costo di performance e copia.
    Suggerimenti e buone pratiche

    Preferisci tipi generic e tipizzazione statica (var quando è chiaro, non dynamic) per sicurezza a compile time.
    Usa decimal (m) per valori monetari per evitare errori di arrotondamento del double.
    Per output di oggetti complessi, Serializzazione JSON (System.Text.Json.JsonSerializer.Serialize(obj)) spesso produce output più leggibile e stabile rispetto a ToString di tipi anonimi.
    Evita dynamic a meno che non lavori con interop COM, reflection complessa o API che lo richiedono — perde i controlli a compile time.
*/

public static class TestDataTypes
{
    public static void Test()
    {
        int myInt = 42;
        long myLong = 1234567890123456789L;
        float myFloat = 35e1F;
        double myDouble = 42.0D;
        decimal myDecimal = 99.99m;
        bool myBoolean = true;
        string myString = "Hello, W'orld!";
        object myObject = new { Property1 = "Value1", Property2 = 123 };
        var myVar = "I am a var type";
        dynamic myDynamic = "I am a dynamic type";

        var person = new Person("Alice", "Johnson", 30, 1);
        var anotherPerson = new Person("Bob", "Smith") { Age = 25 };
        var anotherPersonWithId = new Person("Charlie", "Brown", id: 42);
        var yetAnotherPerson = new Person("David", "Wilson", 40);



        Console.WriteLine($"Integer: {myInt}");
        Console.WriteLine($"Long: {myLong}");
        Console.WriteLine($"Float: {myFloat}");
        Console.WriteLine($"Double: {myDouble}");
        Console.WriteLine($"Decimal: {myDecimal}");
        Console.WriteLine($"Boolean: {myBoolean}");
        Console.WriteLine($"String: {myString}");
        Console.WriteLine($"Object: {myObject}");

        Console.WriteLine($"Var: {myVar}");
        Console.WriteLine($"Dynamic: {myDynamic}");

        myDynamic = 100;
        Console.WriteLine($"Dynamic after change: {myDynamic}");


        Console.WriteLine($"Person: {person.FirstName} {person.LastName}, Age: {person.Age}, Id: {person.Id}");
        Console.WriteLine($"Another Person: {anotherPerson.FirstName} {anotherPerson.LastName}, Age: {anotherPerson.Age}, Id: {anotherPerson.Id}");
        Console.WriteLine($"Another Person: {anotherPersonWithId.FirstName} {anotherPersonWithId.LastName}, Age: {anotherPersonWithId.Age}, Id: {anotherPersonWithId.Id}");
        Console.WriteLine($"Yet Another Person: {yetAnotherPerson.FirstName} {yetAnotherPerson.LastName}, Age: {yetAnotherPerson.Age}, Id: {yetAnotherPerson.Id}");

    }
}
