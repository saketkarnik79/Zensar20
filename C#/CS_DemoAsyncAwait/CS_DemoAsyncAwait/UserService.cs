using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace CS_DemoAsyncAwait
{
    internal class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<User?> GetAndSaveUserAsync(int userId)
        {
            // Fetch user data from an API (I/O-bound operation)
            User? user = await GetUserFromApiAsync(userId);

            // Save user data to a file (I/O-bound operation)
            if (user != null)
            {
                await SaveUserToFileAsync(user);
            }

            return user;
        }

        private async Task SaveUserToFileAsync(User? user)
        {
            string fileName = $"User_{user?.id}.txt";
            string content = $"ID: {user?.id}\nName: {user?.name}\nEmail: {user?.email}";
            await File.WriteAllTextAsync(fileName, content);
        }

        private async Task<User?> GetUserFromApiAsync(int userId)
        {
            string url = $"https://jsonplaceholder.typicode.com/users/{userId}";

            string json = await _httpClient.GetStringAsync(url);

            User? user = JsonSerializer.Deserialize<User>(json);
            return user;
        }
    }
}
