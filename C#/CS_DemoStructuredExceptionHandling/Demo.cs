// <copyright file="Demo.cs" company="Zensar">
// Copyright (c) Zensar. All rights reserved.
// </copyright>

try
{
    int a = 10;
    int b = 0;
    int result = a / b; // Error here

    Console.WriteLine(result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("The divisor can't be a 0;");
    Console.WriteLine(ex.Message);
}
catch (ApplicationException ex)
{
    Console.WriteLine("There is an unknown application error.");
    Console.WriteLine(ex.Message);
}
catch (SystemException ex)
{
    Console.WriteLine("There is an unknown system error.");
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("There is an unknown error.");
    Console.WriteLine(ex.Message);
}
finally
{
    // Runs everytime whether exception is thrown or not
    Console.WriteLine("Cleaning up...");
}

namespace CSDemoStructuredExceptionHandling
{
    // Demo class
    public class Demo
    {
        // Demo field
        int x;
    }
}