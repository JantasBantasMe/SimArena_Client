using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProject.CustomClient
{
    public static class HttpHelper
    {
        public static HttpResponseMessage PostSync(HttpClient client, string url, object? payload)
        {
            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return client.PostAsync(url, content).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage GetSync(HttpClient client, string url)
        {
            return client.GetAsync(url).GetAwaiter().GetResult();
        }

        public static string ReadString(HttpResponseMessage response)
        {
            if (response == null)
            {
                return "Response ist null, go and debug.";
            }

            string body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"API Error {response.StatusCode}: {body}");
            }

            return body;
        }

        public static List<string> ReadList(HttpResponseMessage response)
        {
            string json = ReadString(response);

            return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string> { "Error: Deserialized list was null." };
        }

        public static int ReadInt(HttpResponseMessage response)
        {
            string number = ReadString(response);

            if (int.TryParse(number, out int returnValue))
            {
                return returnValue;
            }
            else
            {
                throw new Exception($"int.TryParse could not parse '{number}' to an int.");
            }
        }
    }
}
