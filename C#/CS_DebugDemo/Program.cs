using System;
using System.Diagnostics;

namespace CS_DebugDemo
{
    class Program
    {
        static int Divide(int x, int y)
        {
            return x / y;
        }

        static void Main()
        {
            int a=10;
            int b=2;
            Debug.WriteLine($"Debug message. Value of b: {b}");
            int result = Divide(a, b);
            Console.WriteLine (result);
        }
    }
}