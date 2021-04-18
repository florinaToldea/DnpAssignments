using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DnpAssignments.Models;

namespace DnpAssignments.Data
{
    public class AdultService
    {
        private string uri = "http://localhost:5001";
        private readonly HttpClient _client;

        public AdultService()
        {
            _client = new HttpClient();
        }
        public async Task<IList<Adult>> GetAllAdultsAsync()
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(uri + "/adults");
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(responseMessage.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result);
            return adults;
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync(uri + "/adults/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.StatusCode}");
            } 
            string result = await response.Content.ReadAsStringAsync(); 
             Adult adult = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions 
             {
                 PropertyNamingPolicy = JsonNamingPolicy.CamelCase
             });
            return adult;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(
                adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(uri + "/adults", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task RemoveAdultAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{uri}/adults/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                throw new Exception($@"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}