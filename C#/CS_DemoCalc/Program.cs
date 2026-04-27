using System;

namespace CS_DemoCalc
{
    class Program
    {
        static void Main()
        {
            float num1;
            float num2;
            float result;
            char op;

            Console.Write("Enter First Number: ");
            num1 = float.Parse(Console.ReadLine()!);
            Console.Write("Enter Second Number: ");
            if(float.TryParse(Console.ReadLine(), out num2) == false)
            {
                Console.WriteLine("\nInvalid input for second number. Exiting Program...");
                return;
            }
            Console.Write("Enter the operator <'+', '-', '*', '/', '%'>: ");
            if(char.TryParse(Console.ReadLine(), out op) == false)
            {
                Console.WriteLine("Invalid input for operator. Exiting Program...");
                return;
            }
            // if(op == '+')
            // {
            //     result = num1 + num2;
            // }
            // else if(op == '-')
            // {
            //     result = num1 - num2;
            // }
            // else if(op == '*')
            // {
            //     result = num1 * num2;
            // }
            // else if(op == '/')
            // {
            //     result = num1 / num2;
            // }
            // else if(op == '%')
            // {
            //     result = num1 % num2;
            // }
            // else
            // {
            //     Console.WriteLine("Sorry. I can't process this operator. Exiting Program...");
            //     return;
            // }

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result=num1-num2;
                    break;
                case '*':
                    result=num1*num2;
                    break;
                case '/':
                    result=num1/num2;
                    break;
                case '%':
                    result=num1%num2;
                    break;
                default:
                     Console.WriteLine("Sorry. I can't process this operator. Exiting Program...");
                     return;
            }

            Console.WriteLine($"{num1} {op} {num2} = {result}");
        }
    }
}