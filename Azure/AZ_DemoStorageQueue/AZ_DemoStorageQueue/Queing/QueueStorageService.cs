using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace AZ_DemoStorageQueue.Queing
{
    internal class QueueStorageService
    {
        private readonly string connectionString = "DefaultEndpointsProtocol=https;AccountName=oizendemostorage;AccountKey=XqSmsFMto6tun1n7j/ookdzcUfpDQha7Ps1504Ht0pJGdj5A4Vc4RYbbwYYV1Uhsq0C3ladVQeVl+AStVdS49A==;EndpointSuffix=core.windows.net";
        private readonly string queueName = "orders-queue";

        public async Task RunAsync()
        {
            // Create queue client
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue if not exists
            await queueClient.CreateIfNotExistsAsync();
            Console.WriteLine("Queue ready...");

            // Send the message
            string messageText = "New order: OrderId=123";
            await queueClient.SendMessageAsync(messageText);
            Console.WriteLine("Message sent to the queue successfully...");

            // Receive message
            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 1);

            foreach (QueueMessage message in messages)
            {
                Console.WriteLine($"Processing message: {message.Body.ToString()}");

                // Simulate processing
                await Task.Delay(1000);

                // Delete message after processing
                await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);

                Console.WriteLine("Message deleted...");
            }
        }
    }
}
