using System;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace CS_DemoProfiling
{
    class Program
    {
        static void Main()
        {
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 1_000_000; i++)
            {
                Math.Sqrt(i);
            }

            sw.Stop();
            Console.WriteLine($"Time taken: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"PID: {Process.GetCurrentProcess().Id}");
            Console.ReadKey();
        }
    }
}