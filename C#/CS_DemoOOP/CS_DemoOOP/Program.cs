using CS_DemoOOP.Demographics;
using CS_DemoOOP.Arithmetic;
using CS_DemoOOP.Banking;
using CS_DemoOOP.Insurance;

namespace CS_DemoOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Person person1 = new Person();
            //    //person1.id = 1;
            //    //person1.name = "John Doe";
            //    //person1.dateOfBirth = new DateTime(1990, 5, 15);
            //    person1.Id = 1;
            //    person1.Name = "John Doe";
            //    person1.DateOfBirth = new DateTime(1990, 5, 15);

            //    Person person2 = new Person(2, "Jane Smith", new DateTime(1985, 10, 20));

            //    Console.WriteLine(person1.DisplayInfo());
            //    Console.WriteLine(person2.DisplayInfo());
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Cleaning up...");
            //}

            //Console.WriteLine($"Add(20, 10): {Calc.Add(20, 10)}");
            //Console.WriteLine($"Add(5, 10, 15): {Calc.Add(5, 10, 15)}");
            //Console.WriteLine($"Add(\"Hello, \", \"World!\"): {Calc.Add("Hello, ", "World!")}");
            //Console.WriteLine($"Subtract(20, 10): {Calc.Subtract(20, 10)}");
            //Console.WriteLine($"Multiply(5, 10): {Calc.Multiply(5, 10)}");
            //Console.WriteLine($"Divide(20, 10): {Calc.Divide(20, 10)}");

            //Person emp1=new Employee(1, "Alice Johnson", new DateTime(1988, 3, 25), 101, 75000);
            //Console.WriteLine(emp1.DisplayInfo());

            AccountBase account = new SavingsAccount();
            Console.WriteLine(account.Balance);
            try
            {
                account.Deposit(10000);
                Console.WriteLine(account.Balance);
                decimal premium = (account as IInsurance)?.GetPremium() ?? 0;
                Console.WriteLine($"Deducting Insurance Premium: {premium}");
                account.Withdraw(premium);
                Console.WriteLine(account.Balance);
                account.Withdraw(7000);
                Console.WriteLine(account.Balance);
                account.Withdraw(4000);
                Console.WriteLine(account.Balance);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(account.Balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Transaction completed. Cleaning Up...");
            }

            Console.Write("\nProgram completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
