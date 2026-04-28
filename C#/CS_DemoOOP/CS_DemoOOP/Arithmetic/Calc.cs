using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Arithmetic
{
    internal static class Calc
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Add(double a, double b, double c) // Overloading method
        {
            return a + b + c;
        }

        public static string Add(string a, string b) // Overloading method
        {
            return $"{a}{b}";
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
    }
}
