
using cSharpCourse.lib;
using System.Diagnostics;

public static class Unused
{

    public static void TestClasses()
    {
        Console.WriteLine("This is a test method in Unused class.");

        Cat cat = new()
        {
            Name = "Whiskers",
            Age = 3,
            Species = "Felis catus"
        };

        cat.Sleep();
        cat.AnimalSound();
        cat.Eat();

        Console.WriteLine($"Cat Name: {cat.Name}, Age: {cat.Age}, Species: {cat.Species}");

        cat.Log("Cat log entry");
        cat.Log("Another cat log entry");

        foreach (var item in cat.ListLogs)
        {
            Console.WriteLine(item);
        }


        Animal dog = new Dog();  // Create a Dog object
        dog.Sleep();
        dog.Eat();
        dog.Log("Dog log entry");

        Farm myFarm = new()
        {
            Name = "Green Farm",
            Location = "Texas",
            Owner = new Person("Alice", "Johnson") { Id = 10, Age = 45 }
        };

        myFarm.AddAnimal(cat);
        myFarm.AddAnimal(dog);
        myFarm.AddAnimal(new Pig());
        myFarm.AddAnimal(new Lion());
        myFarm.AddAnimal(new Lion());


        myFarm.MakeAllSounds();

        return;
        Person father = new("John", "Doe");
        Person mother = new("Jane", "Smith");
        Person kid1 = father with { FirstName = "Jimmy" };
        Person kid2 = mother with { FirstName = "Jenny" };

        Person grandpa = new("Jimmy", "Doe");

        var familyMembers = new[]
        {
                father,
                mother,
                kid1,
                kid2
            };

        foreach (var p in familyMembers)
        {
            Console.WriteLine($"Person: {p.FirstName} {p.LastName}");
        }

        Console.WriteLine($"Are the kids equal? {grandpa == kid1}");
        Console.WriteLine($"Are the kids equal? {grandpa == kid2}");
    }


    public static void TestLocalFunction()
    {
        static int LocalFunction(int x, out int y) => (y = x * 2);

        var t = LocalFunction(5, out int result);
        Console.WriteLine($"LocalFunction returned: {t}, Result: {result}");
    }

    public static void TestArray()
    {
        int[] numbers = [10, 20, 30, 40, 50];

        Console.WriteLine($"Initial length: {numbers.Length}");

        try
        {
            Array.Resize(ref numbers, 6);
            numbers[5] = 35;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Index out of range exception caught: {ex.Message}");
        }

        foreach (var num in numbers)
        {
            Console.WriteLine($"Number in foreach: {num}");
        }
    }

    public static void TestList()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine($"Initial count: {list.Count}");

        list.Add(6);
        list.Add(7);

        foreach (var item in list)
        {
            Console.WriteLine($"List item: {item}");
        }
    }

    private class MyList<T> : IEnumerable<T>
    {
        private readonly List<T> _internalList = new();
        public int Count => _internalList.Count;
        public void Add(T item)
        {
            _internalList.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        public void PrintAll()
        {
            foreach (var item in _internalList)
            {
                Console.WriteLine($"Item: {item}");
            }
        }
    }

    public static void TestList2()
    {
        var list = new MyList<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine($"Initial count: {list.Count}");

        list.Add(6);
        list.Add(7);
        list.PrintAll();
    }

    public static void TestSortedSet()
    {
        var sortedSet = new SortedSet<int> { 5, 3, 1, 4, 2 };

        Console.WriteLine($"Initial count: {sortedSet.Count}");

        sortedSet.Add(3); // Duplicate, won't be added
        sortedSet.Add(6);
        sortedSet.Add(0);

        foreach (var item in sortedSet)
        {
            Console.WriteLine($"SortedSet item: {item}");
        }
    }

    public static void TestLinkedHashSet()
    {
        var linkedHashSet = new LinkedList<int>();
        var set = new HashSet<int>();

        void Add(int item)
        {
            if (set.Add(item))
            {
                linkedHashSet.AddLast(item);
            }
        }

        Add(1);
        Add(2);
        Add(3);
        Add(2); // Duplicate, won't be added
        Add(4);

        Console.WriteLine($"LinkedHashSet count: {linkedHashSet.Count}");

        foreach (var item in linkedHashSet)
        {
            Console.WriteLine($"LinkedHashSet item: {item}");
        }
    }

    public static void TestDictionary()
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
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }


    public static void TestStack()
    {
        var stack = new Stack<string>();

        stack.Push("First");
        stack.Push("Second");
        stack.Push("Third");

        Console.WriteLine($"Stack count after pushes: {stack.Count}");

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            Console.WriteLine($"Popped item: {item}");
        }

        Console.WriteLine($"Stack count after pops: {stack.Count}");
    }


    public static void TestQueue()
    {
        var queue = new Queue<string>();

        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        Console.WriteLine($"Queue count after enqueues: {queue.Count}");

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            Console.WriteLine($"Dequeued item: {item}");
        }

        Console.WriteLine($"Queue count after dequeues: {queue.Count}");
    }

    public static void TestLinkedList()
    {
        var linkedList = new LinkedList<int>();

        linkedList.AddLast(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);

        Console.WriteLine($"LinkedList count after additions: {linkedList.Count}");

        foreach (var item in linkedList)
        {
            Console.WriteLine($"LinkedList item: {item}");
        }

        linkedList.RemoveFirst();
        Console.WriteLine($"LinkedList count after removing first: {linkedList.Count}");

        linkedList.RemoveLast();
        Console.WriteLine($"LinkedList count after removing last: {linkedList.Count}");
    }

}
