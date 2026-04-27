using System;
using static System.Console;

namespace CS_DemoHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteLine($"Hello, {args[0]}!");
            string? name = string.Empty;
            Write("Enter your name: ");
            name = ReadLine();
            if(!string.IsNullOrEmpty(name))
            {
                WriteLine($"Hello, {name}!");
            }
            else
            {
                WriteLine("Hello, World!");
            }
            WriteLine("Welcome to C# Programming!");
        }
    }
}