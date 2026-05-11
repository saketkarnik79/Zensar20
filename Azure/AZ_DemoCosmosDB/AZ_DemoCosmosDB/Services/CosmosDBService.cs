using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using AZ_DemoCosmosDB.Models;
using Newtonsoft.Json;

namespace AZ_DemoCosmosDB.Services
{
    internal class CosmosDBService
    {
        private readonly string connectionString = "AccountEndpoint=https://oizencosmos.documents.azure.com:443/;AccountKey=XzeePa0tp94ocGdHwbtY8tUe2TBTy45hyj4gdfXvoF980xlzAwn0ubd6SEyOKUZtIWkmWwrf1nK0ACDb2CHRug==;";
        private readonly string databaseId = "MyDatabase";
        private readonly string containerId = "Customers";

        private CosmosClient cosmosClient;
        private Container container;

        public async Task RunAsync()
        {
            // Create the cosmos client
            cosmosClient=new CosmosClient(connectionString);

            // Create database
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

            // Create Container with partition key
            container = await database.CreateContainerAsync(containerId, "/city");

            Console.WriteLine("Database & container are ready...");

            // Create item
            var customer = new Customer()
            {
                id=Guid.NewGuid().ToString(),
                name="James",
                city = "London"
            };

            await container.CreateItemAsync(customer, new PartitionKey(customer.city));
            Console.WriteLine("Customer item inserted successfully...");

            // Read customer item
            ItemResponse<Customer> response = await container.ReadItemAsync<Customer>(customer.id, new PartitionKey(customer.city));
            Console.WriteLine($"Read: {response.Resource.name}");

            // Query customer items
            Console.WriteLine("Query results: ");
            var query = container.GetItemQueryIterator<Customer>("SELECT * FROM c WHERE c.city ='London'");

            while (query.HasMoreResults)
            {
                foreach(var item in await query.ReadNextAsync())
                {
                    Console.WriteLine($"{item.name} - {item.city}");
                }
            }

            // Update Item
            customer.city = "Amsterdam";

            await container.UpsertItemAsync(customer, new PartitionKey(customer.city));
            Console.WriteLine("Item updated...");

            // Delete item
            await container.DeleteItemAsync<Customer>(customer.id, new PartitionKey(customer.city));
            Console.WriteLine("Item deleted...");
        }
    }
}
