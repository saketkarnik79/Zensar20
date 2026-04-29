using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoCollections
{
    internal static class NonGenericCollectionsDemo
    {
        public static void ArrayListDemo()
        {
            ArrayList arrayList = new ArrayList();

            // Adding elements of different types to the ArrayList
            arrayList.Add(1);
            arrayList.Add("Two");
            arrayList.Add(3.0);

            // Insert at Index
            arrayList.Insert(1, "Inserted at index 1");

            // Accessing elements
            Console.WriteLine("ArrayList Elements:");
            Console.WriteLine(arrayList[0]); // Output: 1
            Console.WriteLine(arrayList[1]); // Output: Inserted at index 1

            // Iterating through the ArrayList
            foreach (object item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Removing an element
            arrayList.Remove("Two"); // Removes the first occurrence of "Two"
            arrayList.RemoveAt(0); // Removes the first element (1)
        }

        public static void HashTableDemo()
        {
            Hashtable hashtable = new Hashtable();

            // Adding key-value pairs to the Hashtable
            hashtable.Add("Key1", "Value1");
            hashtable.Add("Key2", "Value2");
            hashtable.Add("Key3", "Value3");

            // Accessing values using keys
            Console.WriteLine("Hashtable Values:");
            Console.WriteLine(hashtable["Key1"]); // Output: Value1
            Console.WriteLine(hashtable["Key2"]); // Output: Value2

            // Iterating through the Hashtable
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // Check for the existence of a key
            if (hashtable.ContainsKey("Key2"))
            {
                Console.WriteLine("Key2 exists in the hashtable.");

                // Removing a key-value pair
                hashtable.Remove("Key2"); // Removes the key "Key2" and its associated value
            }
        }

        public static void StackDemo()
        {
            Stack stack = new Stack();

            // Pushing elements onto the stack
            stack.Push(1);
            stack.Push("Two");
            stack.Push(3.0);

            // Accessing the top element
            Console.WriteLine("Top element of the stack: " + stack.Peek()); // Output: 3.0

            // Iterating through the stack
            Console.WriteLine("Stack Elements:");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }

            // Popping an element from the stack
            Console.WriteLine("Popped element: " + stack.Pop()); // Output: 3.0

            // Iterating through the stack
            Console.WriteLine("Stack Elements:");
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }
        }

        public static void QueueDemo()
        {
            Queue queue = new Queue();

            // Enqueuing elements into the queue
            queue.Enqueue(1);
            queue.Enqueue("Two");
            queue.Enqueue(3.0);

            // Accessing the front element
            Console.WriteLine("Front element of the queue: " + queue.Peek()); // Output: 1

            // Iterating through the queue
            Console.WriteLine("Queue Elements:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            // Dequeuing an element from the queue
            Console.WriteLine("Dequeued element: " + queue.Dequeue()); // Output: 1

            // Iterating through the queue
            Console.WriteLine("Queue Elements:");
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }
        }

        public static void SortedListDemo()
        {
            SortedList sortedList = new SortedList();

            // Adding key-value pairs to the SortedList
            sortedList.Add("Key3", "Value3");
            sortedList.Add("Key1", "Value1");
            sortedList.Add("Key2", "Value2");

            // Accessing values using keys
            Console.WriteLine("SortedList Values:");
            Console.WriteLine(sortedList["Key1"]); // Output: Value1
            Console.WriteLine(sortedList["Key2"]); // Output: Value2

            // Iterating through the SortedList (sorted by keys)
            foreach (DictionaryEntry entry in sortedList)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // Check for the existence of a key
            if (sortedList.ContainsKey("Key2"))
            {
                Console.WriteLine("Key2 exists in the sorted list.");

                // Removing a key-value pair
                sortedList.Remove("Key2"); // Removes the key "Key2" and its associated value
            }
        }

        public static void BitArrayDemo()
        {
            BitArray bitArray = new BitArray(8); // Create a BitArray of size 8

            // Setting some bits
            bitArray.Set(0, true); // Set the first bit to true
            bitArray.Set(3, true); // Set the fourth bit to true
            bitArray.Set(5, true); // Set the sixth bit to true

            // Accessing bits
            Console.WriteLine("BitArray Elements:");
            for (int i = 0; i < bitArray.Length; i++)
            {
                Console.WriteLine($"Bit {i}: {bitArray.Get(i)}");
            }

            Console.WriteLine();
            // Iterating through the BitArray
            Console.WriteLine("Iterating through BitArray:");
            foreach (bool bit in bitArray)
            {
                Console.WriteLine(bit);
            }

            // Inverting all bits
            bitArray.Not();
            Console.WriteLine("Inverted BitArray Elements:");
            for (int i = 0; i < bitArray.Length; i++)
            {
                Console.WriteLine($"Bit {i}: {bitArray.Get(i)}");
            }
        }

        public static void NameValueCollectionDemo()
        {
            // NameValueCollection is part of System.Collections.Specialized
            // It allows you to store multiple values for a single key
            System.Collections.Specialized.NameValueCollection nameValueCollection = new System.Collections.Specialized.NameValueCollection();

            // Adding key-value pairs to the NameValueCollection
            nameValueCollection.Add("Key1", "Value1");
            nameValueCollection.Add("Key1", "Value2"); // Adding another value for the same key
            nameValueCollection.Add("Key2", "Value3");

            // Accessing values using keys
            Console.WriteLine("NameValueCollection Values:");
            Console.WriteLine(nameValueCollection["Key1"]); // Output: Value1, Value2
            Console.WriteLine(nameValueCollection["Key2"]); // Output: Value3

            // Iterating through the NameValueCollection
            foreach (string key in nameValueCollection.AllKeys)
            {
                string[] values = nameValueCollection.GetValues(key);
                Console.WriteLine($"{key}: {string.Join(", ", values)}");
            }

            // Check for the existence of a key
            if (nameValueCollection["Key1"] != null)
            {
                Console.WriteLine("Key1 exists in the NameValueCollection.");
                // Removing a key-value pair
                nameValueCollection.Remove("Key1"); // Removes all values associated with "Key1"
            }
        }

        public static void HybridDictionaryDemo()
        {
            // HybridDictionary is part of System.Collections.Specialized
            // It is optimized for small collections and automatically switches to a Hashtable when the collection grows
            System.Collections.Specialized.HybridDictionary hybridDictionary = new System.Collections.Specialized.HybridDictionary();

            // Adding key-value pairs to the HybridDictionary
            hybridDictionary.Add("Key1", "Value1");
            hybridDictionary.Add("Key2", "Value2");
            hybridDictionary.Add("Key3", "Value3");

            // Accessing values using keys
            Console.WriteLine("HybridDictionary Values:");
            Console.WriteLine(hybridDictionary["Key1"]); // Output: Value1
            Console.WriteLine(hybridDictionary["Key2"]); // Output: Value2

            // Iterating through the HybridDictionary
            foreach (System.Collections.DictionaryEntry entry in hybridDictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            // Check for the existence of a key
            if (hybridDictionary.Contains("Key2"))
            {
                Console.WriteLine("Key2 exists in the HybridDictionary.");
                // Removing a key-value pair
                hybridDictionary.Remove("Key2"); // Removes the key "Key2" and its associated value
            }
        }
    }
}
