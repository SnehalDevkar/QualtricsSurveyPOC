using Newtonsoft.Json;
using QualtricsPOC.Entities;
using QualtricsPOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QualtricsPOC.Services
{
    public class HttpService : IHttpService
    {
        private string clientId;
        private string clientSecret;
        public string token;
        public HttpService()
        {
            clientId = "bd9964abfd0ba5b138531b35dd58c7d8";
            clientSecret = "s8hzgG8CyYyKyci9GVTPtuV5ZZB0vqx5X2WQ8rRRJeji0QOzYFMHHsLIlPQM8qav";
        }

        public async Task AuthPost(string uri)
        {
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            var content = new FormUrlEncodedContent(values);

            var authenticationString = $"{clientId}:{clientSecret}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(authenticationString));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
            requestMessage.Content = content;

            //make the request
            using (var client = new HttpClient())
            {

                var response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();

                Authentication authentication = Newtonsoft.Json.JsonConvert.DeserializeObject<Authentication>(response.Content.ReadAsStringAsync().Result);

                if (String.IsNullOrEmpty(token))
                {
                    token = authentication.Access_Token;
                }
            }
        }

        public async Task<string> Post(string uri, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using var httpResponse = await client.PostAsync(uri, body);

                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Put(string uri, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var body = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                using var httpResponse = await client.PutAsync(uri, body);

                httpResponse.EnsureSuccessStatusCode();
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
