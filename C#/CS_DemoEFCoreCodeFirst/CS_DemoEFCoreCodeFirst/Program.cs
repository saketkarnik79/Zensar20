using CS_DemoEFCoreCodeFirst.Data;
using CS_DemoEFCoreCodeFirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CS_DemoEFCoreCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menu driven console application to demonstrate EF Core Code First approach
            using (var context = new AppDbContext()) // Using statement ensures proper disposal of the context
            {
                // Ensure database is created
                //context.Database.EnsureCreated();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("EF Core Code First Demo");
                    Console.WriteLine("1. Add a new product");
                    Console.WriteLine("2. List all products");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AddProduct(context);
                            break;
                        case "2":
                            ListProducts(context);
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }

        public static void AddProduct(AppDbContext context)
        {
            Console.Write("Enter product name: ");
            var name = Console.ReadLine();
            Console.Write("Enter product price: ");
            
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Product not added.");
            }

            Console.Write("Enter product quantity: ");

            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity. Product not added.");
            }
            var product = new Product { Name = name, Price = price, Quantity = quantity };
            context.Products.Add(product);

            try
            {
                //throw new DbUpdateConcurrencyException("Simulated concurrency exception for demonstration purposes.");
                context.SaveChanges();
                Console.WriteLine("Product added successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("A concurrency error occurred. Please try again.");
                Console.WriteLine(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("An error occurred while saving the product. Please try again.");
                Console.WriteLine(ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A database error occurred. Please check your connection and try again.");
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("An error occurred while adding the product. Please try again.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An unexpected error occurred. Please try again.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Add product operation completed.");
                Console.WriteLine("Cleaning up...");
            }
        }

        public static void ListProducts(AppDbContext context)
        {
            var products = context.Products.ToList();
            Console.WriteLine("Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }
    }
}
