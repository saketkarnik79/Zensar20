using CS_DemoEFCoreDBFirst.Models;
using CS_DemoEFCoreDBFirst.Data;

namespace CS_DemoEFCoreDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext()) // Deterministic garbage collection with 'using' statement
            {
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("Menu: PRODUCT MANAGEMENT");
                    Console.WriteLine("1. Display all products");
                    Console.WriteLine("2. Add a new product");
                    Console.WriteLine("3. Update a product");
                    Console.WriteLine("4. Delete a product");
                    Console.WriteLine("5. View a product");
                    Console.WriteLine("6. Exit");

                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            var products = context.Products.ToList();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                            }
                            break;
                        case "2":
                            var newProduct = new Product
                            {
                                Name = "New Product",
                                Price = 9.99m,
                                Quantity = 100
                            };
                            context.Products.Add(newProduct);
                            context.SaveChanges();
                            Console.WriteLine("Product added.");
                            break;
                        case "3":
                            var productToUpdate = context.Products.FirstOrDefault();
                            if (productToUpdate != null)
                            {
                                productToUpdate.Price += 1.00m; // Increase price by $1
                                context.SaveChanges();
                                Console.WriteLine("Product updated.");
                            }
                            else
                            {
                                Console.WriteLine("No products found to update.");
                            }
                            break;
                        case "4":
                            var productToDelete = context.Products.FirstOrDefault();
                            if (productToDelete != null)
                            {
                                context.Products.Remove(productToDelete);
                                context.SaveChanges();
                                Console.WriteLine("Product deleted.");
                            }
                            else
                            {
                                Console.WriteLine("No products found to delete.");
                            }
                            break;
                        case "5":
                            var productToView = context.Products.FirstOrDefault();
                            if (productToView != null)
                            {
                                Console.WriteLine($"ID: {productToView.Id}, Name: {productToView.Name}, Price: {productToView.Price}, Quantity: {productToView.Quantity}");
                            }
                            else
                            {
                                Console.WriteLine("No products found to view.");
                            }
                            break;
                        case "6":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                    Console.WriteLine(); // Add an empty line for better readability
                }
            }
            Console.WriteLine("Program completed. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
