using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AZ_DemoBLOBStorage
{
    internal class Program
    {
        public async static Task UploadBlobAsync()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=oizendemostorage;AccountKey=XqSmsFMto6tun1n7j/ookdzcUfpDQha7Ps1504Ht0pJGdj5A4Vc4RYbbwYYV1Uhsq0C3ladVQeVl+AStVdS49A==;EndpointSuffix=core.windows.net";
            string containerName = "mycontainer";
            string blobName = "myblob.txt";
            string filePath = "myblob.txt";

            // Create a BlobServiceClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            // Create the container if it doesn't exist
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to the blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Create a sample file to upload
            await File.WriteAllTextAsync(filePath, "This is a sample blob content.");

            // Upload the file to the blob (Block Blob)
            await blobClient.UploadAsync(filePath, true);

            // Add metadata to the blob
            var metadata = new Dictionary<string, string>
            {
                { "Author", "YourName" },
                { "Description", "Sample blob for demonstration" }
            };

            // Set the metadata for the blob
            await blobClient.SetMetadataAsync(metadata);

            Console.WriteLine("File successfully uploaded to the Blob!");
        }

        public async static Task DwonloadBlobAsync()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=oizendemostorage;AccountKey=XqSmsFMto6tun1n7j/ookdzcUfpDQha7Ps1504Ht0pJGdj5A4Vc4RYbbwYYV1Uhsq0C3ladVQeVl+AStVdS49A==;EndpointSuffix=core.windows.net";
            string containerName = "mycontainer";
            string blobName = "myblob.txt";
            string filePath = "myblob.txt";

            // Create a BlobClient
            BlobClient blobClient = new BlobClient(connectionString, containerName, blobName);

            // Download the blob to a local file
            await blobClient.DownloadToAsync(filePath.Replace(".txt", "_downloaded.txt"));

            Console.WriteLine("Blob successfully downloaded to local file!"); 
        }

        public async static Task ListBlobsAsync()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=oizendemostorage;AccountKey=XqSmsFMto6tun1n7j/ookdzcUfpDQha7Ps1504Ht0pJGdj5A4Vc4RYbbwYYV1Uhsq0C3ladVQeVl+AStVdS49A==;EndpointSuffix=core.windows.net";
            string containerName = "mycontainer";

            // Create a BlobContainerClient
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            
            // List blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine($"Blob Name: {blobItem.Name}");
            }
        }

        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Uploading Blob...");
                await UploadBlobAsync();

                Console.WriteLine("Listing Blobs...");
                await ListBlobsAsync();

                Console.WriteLine("Downloading Blob..."); 
                await DwonloadBlobAsync();

                Console.WriteLine("All Blob operations completed successfully...");

                Console.WriteLine("Program completed. Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
