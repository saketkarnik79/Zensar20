using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using AZ_TableStorage.Entities;

namespace AZ_TableStorage.Data
{
    internal class TableStorageOps
    {
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=oizendemostorage;AccountKey=XqSmsFMto6tun1n7j/ookdzcUfpDQha7Ps1504Ht0pJGdj5A4Vc4RYbbwYYV1Uhsq0C3ladVQeVl+AStVdS49A==;EndpointSuffix=core.windows.net";
        private readonly string tableName = "Customers";

        public async Task RunAsync()
        {
            // Create a TableClient
            var tableClient = new TableClient(connectionString, tableName);

            // Create table if not exists
            await tableClient.CreateIfNotExistsAsync();

            // Create entity
            var customer = new CustomerEntity()
            {
                PartitionKey = "Customer",
                RowKey = Guid.NewGuid().ToString(),
                Name = "James",
                City = "London",
                Age = 50
            };

            // Insert entity into table
            await tableClient.AddEntityAsync(customer);
            Console.WriteLine("Entity inserted successfully...");

            // Read Entity
            var retrieved = await tableClient.GetEntityAsync<CustomerEntity>(customer.PartitionKey, customer.RowKey);

            Console.WriteLine($"Entity Retrieved: {retrieved.Value.Name}, {retrieved.Value.City}, {retrieved.Value.Age}");

            // Update Entity
            retrieved.Value.City = "Amsterdam";
            await tableClient.UpdateEntityAsync(retrieved.Value, retrieved.Value.ETag, TableUpdateMode.Replace);
            Console.WriteLine("Entity updated...");

            // Query entities (all customers in partition
            Console.WriteLine("Query Results: ");
            await foreach (var entity in tableClient.QueryAsync<CustomerEntity>(c => c.PartitionKey == "Customer")) 
            {
                Console.WriteLine($"{entity.Name}, {entity.City} - {entity.Age}");
            }

            // Delete entity
            await tableClient.DeleteEntityAsync(customer.PartitionKey, customer.RowKey);

            Console.WriteLine("Entity deleted...");
        }
    }
}
