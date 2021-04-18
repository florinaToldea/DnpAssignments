using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public class UserService
    {
        public async  Task<User> ValidateLoginAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync
                ($"https://localhost:5001/users?username={username}&password={password}");
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await responseMessage.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            }

            throw new Exception("User not found!");
        }
    }
}