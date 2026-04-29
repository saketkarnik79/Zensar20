using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoCollections
{
    internal static class GenericCollectionsDemo
    {
        public static void ListDemo()
        {
            // Create a list of integers
            List<int> numbers = new List<int>();

            // Add some numbers to the list
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            // Insert a number at a specific index
            numbers.Insert(1, 10); // Insert 10 at index 1

            // Accessing elements
            Console.WriteLine(numbers[0]); // Output: 1

            // Iterate through the list
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            // Remove an element
            numbers.Remove(2); // Remove the number 2
            numbers.RemoveAt(0); // Remove the element at index 0

            // Iterate through the list
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        public static void DictionaryDemo()
        {
            // Create a dictionary to store key-value pairs
            Dictionary<string, int> ages = new Dictionary<string, int>();

            // Add some key-value pairs to the dictionary
            ages.Add("Alice", 30);
            ages.Add("Bob", 25);
            ages.Add("Charlie", 35);

            // Accessing values using keys
            Console.WriteLine(ages["Alice"]); // Output: 30

            // Iterate through the dictionary
            foreach (KeyValuePair<string, int> kvp in ages)
            {
                Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }

            // Remove a key-value pair
            ages.Remove("Bob");

            // Iterate through the dictionary after removal
            foreach (KeyValuePair<string, int> kvp in ages)
            {
                Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }
        }

        public static void StackDemo()
        {
            // Create a stack of strings
            Stack<string> stack = new Stack<string>();

            // Push some items onto the stack
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            // Peek at the top item
            Console.WriteLine(stack.Peek()); // Output: Third

            // Pop items from the stack
            Console.WriteLine(stack.Pop()); // Output: Third
            Console.WriteLine(stack.Pop()); // Output: Second

            // Check if the stack is empty
            Console.WriteLine(stack.Count == 0); // Output: False
        }

        public static void QueueDemo()
        {
            // Create a queue of strings
            Queue<string> queue = new Queue<string>();

            // Enqueue some items into the queue
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            // Peek at the front item
            Console.WriteLine(queue.Peek()); // Output: First

            // Dequeue items from the queue
            Console.WriteLine(queue.Dequeue()); // Output: First
            Console.WriteLine(queue.Dequeue()); // Output: Second

            // Check if the queue is empty
            Console.WriteLine(queue.Count == 0); // Output: False
        }

        public static void LinkedListDemo()
        {
            // Create a linked list of integers
            LinkedList<int> linkedList = new LinkedList<int>();

            // Add some numbers to the linked list
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);

            // Iterate through the linked list
            foreach (int number in linkedList)
            {
                Console.WriteLine(number);
            }

            // Remove an element
            linkedList.Remove(2); // Remove the number 2

            // Iterate through the linked list after removal
            foreach (int number in linkedList)
            {
                Console.WriteLine(number);
            }
        }

        public static void SortedDictionaryDemo()
        {
            // Create a sorted dictionary to store key-value pairs
            SortedDictionary<string, int> sortedAges = new SortedDictionary<string, int>();

            // Add some key-value pairs to the sorted dictionary
            sortedAges.Add("Charlie", 35);
            sortedAges.Add("Alice", 30);
            sortedAges.Add("Bob", 25);

            // Iterate through the sorted dictionary (keys will be in sorted order)
            foreach (KeyValuePair<string, int> kvp in sortedAges)
            {
                Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }
        }

        public static void SortedListDemo()
        {
            // Create a sorted list to store key-value pairs
            SortedList<string, int> sortedList = new SortedList<string, int>();

            // Add some key-value pairs to the sorted list
            sortedList.Add("Charlie", 35);
            sortedList.Add("Alice", 30);
            sortedList.Add("Bob", 25);

            // Iterate through the sorted list (keys will be in sorted order)
            foreach (KeyValuePair<string, int> kvp in sortedList)
            {
                Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }
        }

        public static void HashSetDemo()
        {
            // Create a hash set to store unique values
            HashSet<string> hashSet = new HashSet<string>();

            // Add some items to the hash set
            hashSet.Add("Apple");
            hashSet.Add("Banana");
            hashSet.Add("Cherry");
            hashSet.Add("Apple"); // Duplicate, will not be added

            // Iterate through the hash set
            foreach (string item in hashSet)
            {
                Console.WriteLine(item);
            }

            // Check if an item exists in the hash set
            Console.WriteLine(hashSet.Contains("Banana")); // Output: True

            // Remove an item from the hash set
            hashSet.Remove("Banana");

            // Check if the item was removed
            Console.WriteLine(hashSet.Contains("Banana")); // Output: False
        }

        public static void SortedSetDemo()
        {
            // Create a sorted set to store unique values in sorted order
            SortedSet<string> sortedSet = new SortedSet<string>();
           
            // Add some items to the sorted set
            sortedSet.Add("Apple");
            sortedSet.Add("Banana");
            sortedSet.Add("Cherry");
            sortedSet.Add("Apple"); // Duplicate, will not be added
            
            // Iterate through the sorted set (items will be in sorted order)
            foreach (string item in sortedSet)
            {
                Console.WriteLine(item);
            }
            
            // Check if an item exists in the sorted set
            Console.WriteLine(sortedSet.Contains("Banana")); // Output: True
            
            // Remove an item from the sorted set
            sortedSet.Remove("Banana");
            
            // Check if the item was removed
            Console.WriteLine(sortedSet.Contains("Banana")); // Output: False
        }

        public static void ReadonlyCollectionDemo()
        {
            // Create a list of integers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
           
            // Create a read-only collection from the list
            IReadOnlyCollection<int> readOnlyNumbers = numbers.AsReadOnly();
           
            // Iterate through the read-only collection
            foreach (int number in readOnlyNumbers)
            {
                Console.WriteLine(number);
            }

            // Attempting to modify the read-only collection will result in a compile-time error
            // readOnlyNumbers.Add(6); // This line will cause an error
        }

        public static void ObserveCollectionDemo()
        {
            // Create an observable collection of strings
            System.Collections.ObjectModel.ObservableCollection<string> observableCollection = new System.Collections.ObjectModel.ObservableCollection<string>();

            // Subscribe to the CollectionChanged event
            observableCollection.CollectionChanged += (sender, e) =>
            {
                Console.WriteLine($"Collection changed: {e.Action}");
            };

            // Add some items to the observable collection
            observableCollection.Add("Item 1");
            observableCollection.Add("Item 2");
            observableCollection.Add("Item 3");
            
            // Remove an item from the observable collection
            observableCollection.Remove("Item 2");
        }
    }
}
